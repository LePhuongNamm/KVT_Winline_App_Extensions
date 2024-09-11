using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Source.Core.Contracts.Basic;
using System.Security.Claims;

namespace Source.WebUI.Authentication
{
    public interface ICookieValidatorService
    {
        Task ValidateAsync(CookieValidatePrincipalContext context);
    }
    public class CookieValidatorService : ICookieValidatorService
    {
        private readonly IWrapperRepository _wrapper;
        public CookieValidatorService(IWrapperRepository wrapper)
        {
            _wrapper = wrapper;
        }

        public async Task ValidateAsync(CookieValidatePrincipalContext context)
        {
            var claimsIdentity = context?.Principal?.Identity as ClaimsIdentity;
            if (claimsIdentity == null || claimsIdentity?.Claims == null || !claimsIdentity.Claims.Any())
            {
                // this is not our issued cookie
                await handleUnauthorizedRequest(context!);
                return;
            }

            var empCode = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            var role = claimsIdentity.FindFirst(ClaimTypes.Role)?.Value;
            if (string.IsNullOrEmpty(empCode) || string.IsNullOrEmpty(role))
            {
                await handleUnauthorizedRequest(context!);
                return;
            }

            var user = await _wrapper.Account.FindUserAsync(empCode);
            if (user == null)
            {
                await handleUnauthorizedRequest(context!);
                return;
            }
        }

        private Task handleUnauthorizedRequest(CookieValidatePrincipalContext context)
        {
            context.RejectPrincipal();
            return context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
