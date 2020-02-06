using System.Web.Http;
using AutoMapper;
using XamarinTest.ApiModels.Models.Account;
using XamarinTest.Domain.Interfaces.Services;

namespace XamarinTest.Web.Controllers.Api {
    [Authorize]
    [RoutePrefix("api/v1/User")]
    public class UserController : ApiController {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService userService) {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IHttpActionResult Get() {
            var user = _mapper.Map<UserApiModel>(
                _userService.GetByEmail(User.Identity.Name));
            return Ok(user);
        }
    }
}
