using ArrayELearnApi.Application.DTOs.Auth;
using ArrayELearnApi.Application.Features.Auth.Commands;
using ArrayELearnApi.Domain.Entities.Auth;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ArrayELearnApi.Application.Features.Auth.Handlers
{
    internal sealed class AssignRolesHandler(UserManager<ApplicationUser> userManager, IMapper mapper, ILogger<AssignRolesHandler> logger) : IRequestHandler<AssignRolesCommand, AuthResponse>
    {
        public async Task<AuthResponse> Handle(AssignRolesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userManager.FindByIdAsync(request.UserId);
                if (user == null)
                {
                    logger.LogError("User not found: {UserID}", request.UserId);
                    return new AuthResponse() { Message = "User not found", IsSuccessed = false };
                }

                // Assign the specified role
                var roleResult = await userManager.AddToRolesAsync(user, request.UserRoles);
                if (!roleResult.Succeeded)
                {
                    var errors = string.Join(", ", roleResult?.Errors.Select(e => e.Description));
                    logger.LogError("Failed to assign user roles: {Errors}", string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                    return new AuthResponse { Message = errors, IsSuccessed = false };
                }

                return new AuthResponse() { Message = "Roles assigned successfully", IsSuccessed = true };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled error in RevokeRolesHandler {Exception}", ex);
                return new AuthResponse() { Message = "Unhandled error in RevokeRoles   Handler", IsSuccessed = false };
            }

        }
    }
}
