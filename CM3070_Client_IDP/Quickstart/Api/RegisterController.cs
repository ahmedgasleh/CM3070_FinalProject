using CM3070_Client_IDP.Models;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CM3070_Client_IDP.Quickstart.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;

        public RegisterController ( SignInManager<IdentityUser> signInManager )
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser ( [FromBody] UserForRegistration userForRegistration )
        {
            if (userForRegistration is null) return BadRequest();

            var user = new IdentityUser();

            user.UserName = userForRegistration.Email;
            user.Email = userForRegistration.Email;


            var result = await _signInManager.UserManager.CreateAsync(user, userForRegistration.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponse { Errors = errors });
            }

            return StatusCode(201);

        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Route("Register")]
        //public async Task<IActionResult> Register ( UserForRegistration userForRegistration )
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(userForRegistration);
        //    }

        //    var user = new IdentityUser();

        //    user.UserName = userForRegistration.Email;
        //    user.Email = userForRegistration.Email;


        //    var result = await _signInManager.UserManager.CreateAsync(user, userForRegistration.Password);

        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.TryAddModelError(error.Code, error.Description);
        //        }
        //        return View(userForRegistration);
        //    }

        //    await _signInManager.UserManager.AddToRoleAsync(user, "admin");


        //    return RedirectToAction(nameof(HomeController.Index), "Home");

        //}
    }
}
