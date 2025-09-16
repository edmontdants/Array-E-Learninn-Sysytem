using ArrayELearnApi.Application.DTOs.Auth;
using ArrayELearnApi.Application.Features.Auth.Commands;
using ArrayELearnApi.Domain.Entities.Auth;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ArrayELearnApi.Application.Features.Auth.Handlers
{
    internal sealed class RevokeRolesCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper, ILogger<RevokeRolesCommandHandler> logger) : IRequestHandler<RevokeRolesCommand, AuthResponse>
    {
        public async Task<AuthResponse> Handle(RevokeRolesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userManager.FindByIdAsync(request.UserId);
                if (user == null)
                {
                    logger.LogError("User not found: {UserID}", request.UserId);
                    return new AuthResponse() { IsSuccessed = false, Message = "User not found" };
                }

                // Revoke the specified role
                var roleResult = await userManager.RemoveFromRolesAsync(user, request.UserRoles);
                if (!roleResult.Succeeded)
                {
                    var errors = string.Join(", ", roleResult?.Errors.Select(e => e.Description));
                    logger.LogError("Failed to revoke user roles: {Errors}", string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                    return new AuthResponse { IsSuccessed = false, Message = errors};
                }

                return new AuthResponse() { IsSuccessed = true, Message = "Roles Revoked successfully" };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled error in RevokeRolesHandler {Exception}", ex);
                return new AuthResponse() { IsSuccessed = false, Message = "Unhandled error in RevokeRolesHandler"};
            }

        }
    }
}
