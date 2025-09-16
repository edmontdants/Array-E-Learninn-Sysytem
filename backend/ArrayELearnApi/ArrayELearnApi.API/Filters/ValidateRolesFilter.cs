using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace ArrayELearnApi.API.Filters
{
    public class ValidateRolesFilter(RoleManager<IdentityRole> roleManager) : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Loop through all action arguments (DTOs from request body, query, etc.)
            foreach (var arg in context.ActionArguments.Values)
            {
                if (arg == null) continue;

                // Find any property called "Role" or "Roles"
                var roleProps = arg.GetType().GetProperties()
                    .Where(p =>
                    p.Name.Equals("Role", StringComparison.OrdinalIgnoreCase)
                    || p.Name.Equals("Roles", StringComparison.OrdinalIgnoreCase)
                    || p.Name.Equals("UserRoles", StringComparison.OrdinalIgnoreCase));

                foreach (var prop in roleProps)
                {
                    var value = prop.GetValue(arg);

                    if (value is string singleRole)
                    {
                        if (!await roleManager.RoleExistsAsync(singleRole))
                        {
                            context.Result = new BadRequestObjectResult(
                                $"Role '{singleRole}' does not exist in the system");
                            return;
                        }
                    }
                    else if (value is IEnumerable<string> roles)
                    {
                        var validRoles = await roleManager.Roles.Select(r => r.Name).ToListAsync();
                        var invalid = roles.Except(validRoles, StringComparer.OrdinalIgnoreCase).ToList();

                        if (invalid.Any())
                        {
                            context.Result = new BadRequestObjectResult(
                                $"Invalid roles: {string.Join(", ", invalid)}");
                            return;
                        }
                    }
                }
            }

            // Proceed if everything is valid
            await next();
        }
    }
}
