using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.WebApp.Core.Requests.Account;
using ProductCatalog.WebApp.Core.Services;
using ProductCatalog.WebApp.ViewModels.Login;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProductCatalog.WebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.GetData(new AuthenticationRequest()
                {
                    Email = model.Email,
                    Password = model.Password
                });

                if (response is not null)
                {
                    await Authenticate(response.Claims.Select(x => new Claim(x.Type, x.Value)));

                    HttpContext.Response.Cookies.Append("token", response.Token);

                    return Redirect(model.ReturnUrl ?? "/");
                }
            }

            ModelState.AddModelError("", "Incorrect username or password");

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.Registration(new RegistrationRequest()
                {
                    Email = model.Email,
                    Password = model.Password1,
                });

                await Authenticate(response.Claims.Select(x => new Claim(x.Type, x.Value)));

                HttpContext.Response.Cookies.Append("token", response.Token);

                return RedirectToAction("Index", "Catalog");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("token");

            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }

        private async Task Authenticate(IEnumerable<Claim> claims)
        {
            var ci = new ClaimsIdentity(claims, "ApplicationCookie", ClaimTypes.Email,
                ClaimTypes.Role);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ci));
        }
    }
}
