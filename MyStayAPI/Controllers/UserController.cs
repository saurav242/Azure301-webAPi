using Agent.Interface;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStayAPI.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserAgent _userAgent;

        public UserController(IUserAgent userAgent)
        {
            _userAgent = userAgent;
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userAgent.GetUserById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("validate")]
        public IActionResult ValidateUser([FromQuery] string email, [FromQuery]string password)
        {
            try
            {
                var user = _userAgent.ValidateUser(email, password);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.ErrorCount+ " Invalid model object");
                }
                if (user == null)
                {
                    return BadRequest("Hotel object is null");
                }
                _userAgent.CreateUser(user);

                return CreatedAtRoute("GetUserById", new { id = user.Id }, user);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
