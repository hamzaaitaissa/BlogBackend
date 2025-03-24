using blogfolio.Entities;
using blogfolio.ENUMS;
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
            var userRole = context.User.FindFirst(ClaimTypes.Role)?.Value;

            if (blog.UserId.ToString() == userId || userRole == "Admin") // If user owns the blog or an Admin, allow access
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    public class CommentOwnerRequirement : IAuthorizationRequirement { }

    public class CommentOwnerHandler : AuthorizationHandler<CommentOwnerRequirement, Comment>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CommentOwnerRequirement requirement, Comment comment)
        {
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = context.User.FindFirst(ClaimTypes.Role)?.Value;
            if(comment.UserId.ToString() == userId && userRole == "Editor" || userRole == "Admin")
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

    public class UserOwnerRequirement : IAuthorizationRequirement { }
    public class UserOwnerHandler : AuthorizationHandler<UserOwnerRequirement, User>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserOwnerRequirement requirement, User user)
        {
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = context.User.FindFirst(ClaimTypes.Role)?.Value;
            if(user.Id.ToString() ==  userId || userRole == "Admin")
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
