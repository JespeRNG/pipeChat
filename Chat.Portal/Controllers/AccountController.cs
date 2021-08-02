using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Chat.Portal.Models;
using Chat.BLL;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Chat.BLL.DTO;

namespace Chat.Portal.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityService _identity;
        private readonly IRegistrationService _authenticationService;

        public AccountController(IIdentityService identity, IRegistrationService authentication)
        {
            _identity = identity;
            _authenticationService = authentication;
        }

        private void CreateClaim(string Username)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(nameof(Chat), ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, Username, ClaimValueTypes.String));

            var owinCtx = Request.GetOwinContext();
            owinCtx.Authentication.SignIn(
                properties: new AuthenticationProperties
                {
                    IssuedUtc = DateTime.UtcNow,
                    ExpiresUtc = DateTime.UtcNow.AddDays(7),
                },
                identities: claimsIdentity);
        }

        [HttpPost]
        public async Task<ActionResult> SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password == model.RePassword)
                {
                    var dto = new CreateUserDTO
                    {
                        Email = model.Email,
                        Username = model.Username,
                        Password = model.Password
                    };

                    if (model.LastName != String.Empty || model.FirstName != String.Empty)
                    {
                        dto.FirstName = model.FirstName;
                        dto.LastName = model.LastName;
                    }
                    else
                    {
                        dto.FirstName = null;
                        dto.LastName = null;
                    }

                    var regResult = _authenticationService.RegisterUser(dto);
                    if (regResult.Success)
                    {
                        CreateClaim(model.Username);
                        return RedirectToAction("Home", "Home");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Wrong password or login.");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _identity.VerifyCredential(model.Username, model.Password);

                if (result.Success)
                {
                    CreateClaim(model.Username);
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong password or login.");
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [Route(Name = "Second")]
        public ActionResult SignUp()
        {
            return View();
        }
    }
}