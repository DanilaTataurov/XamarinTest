using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using XamarinTest.Domain.Entities;

namespace XamarinTest.Web.Controllers.Api {
    public class AuthController : ApiController {
        public AuthController() { }

        private TestUserManager _userManager;

        public TestUserManager UserManager {
            get => _userManager ?? Request.GetOwinContext().GetUserManager<TestUserManager>();
            private set => _userManager = value;
        }

        [Route("api/Auth/Register")]
        [HttpPost]
        public async Task<IHttpActionResult> RegisterAsync(string username, string password) {
            try {
                var user = new User {
                    UserName = username, Email = username
                };

                var result = await UserManager.CreateAsync(user, password);
                if (result.Succeeded) {
                    return Ok();
                } else {
                    return BadRequest(result.Errors.ToString());
                }
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Auth/Logout")]
        public async Task<IHttpActionResult> LogoutAsync() {
            try {
                if (User.Identity.IsAuthenticated) {
                    Request.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
                }
                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Auth/CheckEmail")]
        public async Task<IHttpActionResult> CheckEmailAsync(string email) {
            try {
                var user = await UserManager.FindByEmailAsync(email);
                if (user == null) {
                    return BadRequest("User is not found");
                }

                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
