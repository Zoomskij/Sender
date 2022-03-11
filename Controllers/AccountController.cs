using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using PrintLayer.Models;
using PrintLayer.Services.Interfaces;

namespace PrintLayer.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View("Index");
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<User> Login([FromBody] LoginModel credentials)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest();
            }

           // if (HttpContext.User != null)
           //     await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var user = await _authService.LoginAsync(credentials.Login, credentials.Password);

            if (user == null) return null;

            var nameIdentifier = user.Id.ToString();


            var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            //claimsIdentity.AddClaims(user.ClaimValues.Select(claimValue => new Claim(claimValue.Name, claimValue.Value ?? "")));
            claimsIdentity.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));

            //foreach (var role in user.Roles)
            //{
            //    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
            //}

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            SignIn(claimsPrincipal, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddDays(1),
                IsPersistent = false,
                IssuedUtc = DateTime.UtcNow
            }, CookieAuthenticationDefaults.AuthenticationScheme);
            return user;

        }


        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<User> Registration([FromBody] LoginModel credentials)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest();
            }

            // if (HttpContext.User != null)
            //     await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var user = await _authService.CreateUserAsync(credentials.Login, credentials.Password);

            if (user == null) return null;

            var nameIdentifier = user.Id.ToString();

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
            return user;


        }

        [HttpPost("[action]")]
        public ActionResult Logout()
        {
            if (HttpContext.User == null)
                return BadRequest();

            return SignOut(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
