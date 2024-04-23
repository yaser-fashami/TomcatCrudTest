using System.Security.Claims;

namespace Mc2.CrudTest.Framework.EndPoints.WebMVC.Extensions;

public static class ClaimExtension
{
    public static string GetClaim(this ClaimsPrincipal userClaimPrincipal, string claimType)
    {
        return userClaimPrincipal.Claims.FirstOrDefault((Claim x) => x.Type == claimType)?.Value;
    }
}
