using Microsoft.AspNetCore.Mvc;
using UserPortalAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace UserPortalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _config;

        public UsersController(IConfiguration config)
        {
            _config = config;
        }

        //  Register a new user using stored procedure
        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] UserRegistrationDto user)
        {
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_RegisterUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@StateId", user.StateId);

                    cmd.ExecuteNonQuery();
                }
            }
            return Ok(new { Message = "User registered successfully!" });
        }

        //  Get user details by UserId
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    string query = @"
                        SELECT UserId, Username, PhoneNumber, Email, StateId, CreatedAt
                        FROM Users
                        WHERE UserId = @UserId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var user = new
                                {
                                    UserId = reader["UserId"],
                                    Username = reader["Username"],
                                    PhoneNumber = reader["PhoneNumber"],
                                    Email = reader["Email"],
                                    StateId = reader["StateId"],
                                    CreatedAt = reader["CreatedAt"]
                                };
                                return Ok(user);
                            }
                            else
                            {
                                return NotFound(new { Message = "User not found" });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        //  Get all registered users
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    string query = @"
                        SELECT UserId, Username, PhoneNumber, Email, StateId, CreatedAt
                        FROM Users";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            var users = new List<object>();
                            while (reader.Read())
                            {
                                users.Add(new
                                {
                                    UserId = reader["UserId"],
                                    Username = reader["Username"],
                                    PhoneNumber = reader["PhoneNumber"],
                                    Email = reader["Email"],
                                    StateId = reader["StateId"],
                                    CreatedAt = reader["CreatedAt"]
                                });
                            }
                            return Ok(users);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //  Return 500 status code for any server/database error
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
