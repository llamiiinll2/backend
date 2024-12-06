using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("[action]")]
        public ActionResult Login(LoginParam param)
        {
            if (param.UserName == "Admin" && param.Password == "123456")
            {
                return Ok(new
                {
                    status =200,
                    message="Login success"
                });
            }
            return BadRequest(new
            {
                status = 404,
                message = "User Not Found"
            });
        }
    }
    public class LoginParam
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }

}
