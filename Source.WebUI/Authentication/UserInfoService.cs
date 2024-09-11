using Microsoft.AspNetCore.Components.Authorization;
using Source.Core.DTOs;
using System.Security.Claims;

namespace Source.WebUI.Authentication
{
    public interface IUserInfoService
    {
        Task<CurrentUserInfoDTO?> GetUserAsync();
    }

    public class UserInfoService : IUserInfoService
    {
        private readonly AuthenticationStateProvider _state;
        public UserInfoService(AuthenticationStateProvider state) =>
            _state = state ?? throw new ArgumentNullException(nameof(state));

        public async Task<CurrentUserInfoDTO?> GetUserAsync()
        {
            var _result = (CurrentUserInfoDTO?)null!;
            var authState = await _state.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user != null && user.Identity != null && user.Identity.IsAuthenticated)
            {
                _result = new CurrentUserInfoDTO()
                {
                    UserName = user.Claims.First(x => x.Type == ClaimTypes.Name).Value!,
                    Role = user.Claims.First(x => x.Type == ClaimTypes.Role).Value!,
                };
            }
            return _result;
        }
    }
}
