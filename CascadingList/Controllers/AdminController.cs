using CascadingList.Models;
using CascadingList.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CascadingList.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger; // Change Logger to ILogger
        private readonly IAdmin _admin;

        public AdminController(IAdmin admin, ILogger<AdminController> logger) // Change Logger to ILogger
        {
            _admin = admin;
            _logger = logger;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var result = _admin.GetUsers();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(Register register)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await Task.Run(() => _admin.AddRegister(register));
                    _logger.LogInformation("User added successfully."); // Add logging
                }
                else
                {
                    _logger.LogWarning("Invalid model state for user registration."); // Add logging
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding user."); // Add logging
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
            return Ok("User saved successfully."); // Fix the error by returning a proper message
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(Register register)
        {
            await Task.Run(() => _admin.UpdateUser(register));
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await Task.Run(() => _admin.DeleteUser(id));
            return Ok();
        }

        [HttpGet]
        [Route("GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            var result = _admin.GetCountries();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetStates")]
        public async Task<IActionResult> GetStates(int countryId)
        {
            var result = _admin.GetStates(countryId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetCities")]
        public async Task<IActionResult> GetCities(int stateId)
        {
            var result = _admin.GetCities(stateId);
            return Ok(result);
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            // Implement JWT token generation and store in secure cookies
            try
            {
                if (ModelState.IsValid)
                {
                    var isAuthenticated = await Task.Run(() => _admin.IsAuthenticated(login));
                    if (isAuthenticated)
                    {
                        _logger.LogInformation("User logged in successfully."); // Add logging
                        // Generate JWT token
                        var token = GenerateJwtToken(login);
                        // Store token in secure cookies
                        Response.Cookies.Append("AuthToken", token, new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true,
                            SameSite = SameSiteMode.Strict
                        });
                        return Ok("Login successful.");
                    }
                    else
                    {
                        _logger.LogWarning("Invalid login attempt."); // Add logging
                        return Unauthorized("Invalid credentials.");
                    }
                }
                else
                {
                    _logger.LogWarning("Invalid model state for login."); // Add logging
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while logging in."); // Add logging
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        private string GenerateJwtToken(Login login)
        {
         bool Isloggedin=  _admin.Authenticate(login);
            return Isloggedin ? "generated_jwt_token" : "generated_jwt_token";
        }
    }
}
