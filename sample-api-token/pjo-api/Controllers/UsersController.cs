using System;
using System.Linq;
using System.Web.Http;
using pjo_api.Models;
using pjo_api.Provider;
using pjo_api.Services;

namespace pjo_api.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("getall")]
        [CustomAuthorize(Roles = "Admin")]
        public IHttpActionResult Get()
        {
            try
            {
                var data = UsersService.GetUsers();
                return Ok(new
                {
                    Data = data
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("getbyid")]
        [Authorize]
        public IHttpActionResult GetById(int id)
        {
            var data = UsersService.GetUsers();
            return Ok(data.Any(c => c.Id == id) ? data.SingleOrDefault(c => c.Id == id) : null);
        }

        [HttpPost]
        [Route("adduser")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PostData([FromBody]User user)
        {
            return Ok(UsersService.AddUser(user));
        }
    }
}
