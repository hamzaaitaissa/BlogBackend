using blogfolio.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace blogfolio.Policies
{
    public class BlogOwnerRequirement : IAuthorizationRequirement { }

    public class BlogOwnerHandler : AuthorizationHandler<BlogOwnerRequirement, Blog>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BlogOwnerRequirement requirement, Blog blog)
        {
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (blog.UserId.ToString() == userId) // If user owns the blog, allow access
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

/*
Checks if the logged-in user owns the blog.
If yes, access is granted.
If not, the request is denied.
 
context provides information about the user and the resource being accessed.

1️⃣ context.User → Represents the logged-in user (contains claims like UserId, Role, Email).
2️⃣ context.Resource → Represents what is being accessed (e.g., a Blog object).
3️⃣ context.Succeed(requirement) → ✅ Grants access if the requirement is met.
4️⃣ context.Fail() → ❌ Denies access explicitly.
5️⃣ context.HasSucceeded → ✅ Checks if access was already granted.
 
 */
