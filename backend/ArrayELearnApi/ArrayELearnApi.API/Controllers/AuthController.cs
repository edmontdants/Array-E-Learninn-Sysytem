using ArrayELearnApi.Application.Features.Auth.Commands;
using ArrayELearnApi.Application.Interfaces;
using ArrayELearnApi.Domain.Entities.Auth;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArrayELearnApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AuthController(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                IMediator mediator,
                                IValidationService validator,
                                IServiceProvider serviceProvider) : ControllerBase
    {
        [Authorize(Roles = "Owner, Admin")]
        [HttpPost("revoke-roles")]
        public async Task<IActionResult> AssignRoles([FromBody] RevokeRolesCommand request,
                                                     [FromServices] IValidator<RevokeRolesCommand> validator)
        {
            //var validator = serviceProvider.GetRequiredService<IValidator<AssignRolesCommand>>();
            //await validator.ValidateAsync(request, cancellation);
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var result = await mediator.Send(request);
            return Ok("Roles assigned successfully");
        }

        [Authorize(Roles = "Owner, Admin")]
        [HttpPost("assign-roles")]
        public async Task<IActionResult> AssignRoles([FromBody] AssignRolesCommand request,
                                                     [FromServices] IValidator<AssignRolesCommand> validator,
                                                     CancellationToken cancellation)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var result = await mediator.Send(request);
            return Ok("Roles assigned successfully");
        }

        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand request,
                                                  [FromServices] IValidator<RegisterCommand> validator,
                                                  CancellationToken cancellation)
        {
            var validationResult = await validator.ValidateAsync(request, cancellation);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var result = await mediator.Send(request);
            return result.IsSuccessed ? Ok(result) : BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand request,
                                               [FromServices] IValidator<LoginCommand> validator,
                                               CancellationToken cancellation)
        {
            var validationResult = await validator.ValidateAsync(request, cancellation);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var result = await mediator.Send(request);
            return result.IsSuccessed ? Ok(result) : Unauthorized(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok(new { message = "Logged out successfully" });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommand request)
        {
            var result = await mediator.Send(request);
            return result == null ? Unauthorized(new { message = "Invalid or expired refresh token." }) : Ok(result);
        }

        [Authorize]
        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeToken(RevokeRefreshTokenCommand request) => Ok(await mediator.Send(request));
    }
}
