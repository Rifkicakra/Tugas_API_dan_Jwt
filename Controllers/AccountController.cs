using API_dan_JWT.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using API_dan_JWT.Repository;
using API_dan_JWT.Repositories;
using API_dan_JWT.Models;

namespace API_dan_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Karyawan,Admin")]
    public class AccountController : ControllerBase
    {
        private readonly AccountRepositories accountRepositories;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountController> _logger;
        public AccountController(AccountRepositories accountRepositories, IConfiguration configuration, ILogger<AccountController> logger)
        {
            this.accountRepositories = accountRepositories;
            _configuration = configuration;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var data = accountRepositories.Get();
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Not Found "
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Found",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            var data = accountRepositories.GetById(Id);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Not Found"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Found",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpPost("Create")]
        public ActionResult Create(User user)
        {
            var data = accountRepositories.Create(user);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Enter Failed"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Success",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpPut("Update")]
        public ActionResult Update(User user)
        {
            var data = accountRepositories.Update(user);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Not Updated"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Updated",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var data = accountRepositories.Delete(id);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Gagal Dihapus"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil Dihapus",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public ActionResult Register(string fullname, string email, DateTime birthdate, string password)
        {
            var data = accountRepositories.Register(fullname, email, birthdate, password);

            try
            {
                if (data == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Email sudah ada !"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Berhasil",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult Login(string email, string password)
        {
            var data = accountRepositories.Login(email, password);
            try
            {
                if (data == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Login gagal",
                    });
                }
                else
                {
                    string token = Token(email);
                    return Ok(new
                    {
                        Message = "Login Berhasil",
                        Data = data,
                        token
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

       // [HttpGet("{email}")]
        private string Token(string email)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,email)

            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                 _configuration["Jwt:Issuer"],
                 _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        [HttpPut("ChangePassword")]
        public ActionResult ChangePassword(string pw, string password, string email)
        {

            var data = accountRepositories.ChangePassword(pw, password, email);
            try
            {
                if (data == 0)
                {
                    return Ok(new { Message = "error" });
                }
                else
                {
                    return Ok(new
                    {
                        Message = "Sukses",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }


        [HttpPut("ForgotPassword")]
        public ActionResult ForgotPassword(string fullName, string email, string birthDate, string newPassword)
        {
            var data = accountRepositories.ForgotPassword(fullName, email, birthDate, newPassword);
            try
            {
                if (data == 0)
                {
                    return Ok(new 
                    { 
                        Message = "Gagal" 
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Message = "Sukses",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

    }
}
