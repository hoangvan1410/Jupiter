using GAO.WebApi.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace GAO.WebApi.Infrastructure.Auth.Permissions;

public class MustHavePermissionAttribute : AuthorizeAttribute
{
    public MustHavePermissionAttribute(string action, string resource) =>
        Policy = GAOPermission.NameFor(action, resource);
}