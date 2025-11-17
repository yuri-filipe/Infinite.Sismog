using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sismog.Models;
using Sismog.Services.Interfaces;
using System.Security.Claims;

namespace Sismog.Controllers
{
    [Authorize]
    [Route("/user/")]
    public class UserController : CustomController
    {
        private readonly IUserService _userService;
        private readonly IDatabaseService _databaseService;

        public UserController(IUserService userService, IDatabaseService databaseService)
        {
            _userService = userService;
            _databaseService = databaseService;
        }


        [HttpGet("login")]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost("login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Login model)
        {
            var result = _userService.ValidarCredenciais(model.UserName, model.Senha);

            if (result == "success")
            {
                var user = await _userService.GetUser(model.UserName);

                await AddUserContext(user);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Error", "Credenciais inválidas");
            return View("Login", model);

        }
        [HttpGet("logout")]
        public async Task<ActionResult> Logout()
        {
            var user = User.Identity.Name;
            _ = await _userService.DesconectarUsuario(user);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");

        }
        private async Task AddUserContext(User user)
        {

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Login),
                new Claim("name", user.Login)
            };
            claims.AddRange(user.Papeis.OrderBy(p => p).Select(papel => new Claim(ClaimTypes.Role, papel)));

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", null);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal, new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
            });
        }

    }
}
