using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Phoenix.Business.Interfaces;
using Phoenix.Presentation.Web.ViewModels;
using System.Security.Claims;

namespace Phoenix.Presentation.Web.Services
{
    public class AuthService
    {
        private readonly IAuthRepository _repository;
        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public AuthenticationTicket Login(LoginFormViewModel vm)
        {
            if (vm.Role == "Administrator")
            {
                var accountData = _repository.GetAdminAccount(vm.Username);
                VerifyPassword(vm.Password, accountData.Password);
                var claims = new List<Claim>{
                new Claim("username", accountData.Username),
                new Claim(ClaimTypes.Role, vm.Role)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var authenticationProperties = new AuthenticationProperties
                {
                    IssuedUtc = DateTime.Now,
                    ExpiresUtc = DateTime.Now.AddMinutes(30)
                };

                return new AuthenticationTicket(principal, authenticationProperties, CookieAuthenticationDefaults.AuthenticationScheme);
            }
            else
            {
                var accountData = _repository.GetGuestAccount(vm.Username);
                VerifyPassword(vm.Password, accountData.Password);
                var claims = new List<Claim>{
                new Claim("username", accountData.Username),
                new Claim(ClaimTypes.Role, vm.Role)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var authenticationProperties = new AuthenticationProperties
                {
                    IssuedUtc = DateTime.Now,
                    ExpiresUtc = DateTime.Now.AddMinutes(30)
                };

                return new AuthenticationTicket(principal, authenticationProperties, CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }
        private void VerifyPassword(string enteredPassword, string storedPassword)
        {
            bool isCorrectPassword = BCrypt.Net.BCrypt.Verify(enteredPassword, storedPassword);

            if (!isCorrectPassword)
            {
                throw new InvalidOperationException("Username or password is incorrect");
            }
        }
    }
