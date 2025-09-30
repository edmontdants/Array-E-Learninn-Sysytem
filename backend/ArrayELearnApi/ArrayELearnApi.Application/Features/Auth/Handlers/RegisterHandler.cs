using ArrayELearnApi.Application.DTOs.Auth;
using ArrayELearnApi.Application.Features.Auth.Commands;
using ArrayELearnApi.Application.Interfaces.Auth;
using ArrayELearnApi.Domain.Constants;
using ArrayELearnApi.Domain.Entities.Auth;
using ArrayELearnApi.Domain.Entities.Domain;
using ArrayELearnApi.Domain.Interfaces.UoW;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Data;

namespace ArrayELearnApi.Application.Features.Auth.Handlers
{
    public class RegisterHandler(IApplicationUnitOfWork uow,
                                 UserManager<ApplicationUser> userManager,
                                 IMapper mapper,
                                 IJwtTokenGenerator JwtTokenGenerator,
                                 ILogger<RegisterHandler> logger) : IRequestHandler<RegisterCommand, AuthResponse>
    {
        public async Task<AuthResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            
            using var transaction = uow.BeginTransaction();
            try
            {
                //var existingEmail = await userManager.FindByEmailAsync(request.Email);
                //if (existingEmail is not null)
                //    return new AuthResponse { Message = "Email is Already registered.", IsAuthed = false };

                var user = mapper.Map<ApplicationUser>(request);
                user.CREATEDBY = user.Id;
                var result = await userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result?.Errors.Select(e => e.Description));
                    logger.LogError("User registration failed: {Errors}", errors);
                    return new AuthResponse { IsSuccessed = false, Message = errors };
                }

                //Assign default role if not specified
                if (request.UserRoles?.Count == 0)
                {
                    var roleResult = await userManager.AddToRoleAsync(user, UserRole.Student);
                    if (!roleResult.Succeeded)
                    {
                        var errors = string.Join(", ", roleResult?.Errors.Select(e => e.Description));
                        logger.LogError("Failed to assign default role: {Errors}", string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                        return new AuthResponse { IsSuccessed = false, Message = errors };
                    }
                    
                    var studentRepository = uow.studentRepository;
                    var student = mapper.Map<Student>(user);
                    student.CREATEDBY = user.Id;
                    studentRepository.Add(student);
                    await studentRepository.SaveChangesAsync();
                }
                else
                {
                    //foreach (var role in request.UserRoles)
                    //{
                        //if (Enum.IsDefined(typeof(Domain.Enums.UserRole), role))
                        //{

                        //}
                        //else
                        //{
                        //    logger.LogWarning("Invalid role specified: {Role}", role);
                        //}
                    //}
                    
                    // Assign the specified role
                    var roleResult = await userManager.AddToRolesAsync(user, request.UserRoles);
                    if (!roleResult.Succeeded)
                    {
                        var errors = string.Join(", ", roleResult?.Errors.Select(e => e.Description));
                        logger.LogError("Failed to assign user roles: {Errors}", string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                        return new AuthResponse { IsSuccessed = false, Message = errors };
                    }
                }
                
                var jwtToken = await JwtTokenGenerator.GenerateJwtTokenAsync(user);

                transaction.Commit();
                return new AuthResponse { IsSuccessed = true, Message = "User registered successfully",  AccessToken = jwtToken };
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                logger.LogError(ex, "Unhandled error in RegisterHandler {Exception}", ex);
                return new AuthResponse { IsSuccessed = false, Message = "Unhandled error in RegisterHandler" };
            }
        }
    }
}
