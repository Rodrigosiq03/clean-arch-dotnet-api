using Application.DTOs;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("~/api/create-user", Name = "Add")]
    public async Task<ActionResult> Add([FromBody] UserDTO userDto)
    {
        var userAdded = await _userService.AddUser(userDto);
        if (userAdded == null)
        {
            return BadRequest(new ApiResponse { Message = "Some parameters are invalid!" });
        }

        var response = new ApiResponse
        {
            User = userAdded,
            Message = "User created successfully!"
        };

        return CreatedAtAction(nameof(GetByRa), new { ra = userAdded.Ra }, response);
    }
    
    [HttpPut("~/api/update-user", Name = "Update")]
    public async Task<ActionResult> Update([FromQuery] string ra)
    {
        var userUpdated = await _userService.UpdateUser(ra);
        if (userUpdated == null)
        {
            return BadRequest(new ApiResponse { Message = "Some parameters are invalid to update this user!" });
        }

        return Ok(new ApiResponse { User = userUpdated, Message = "User updated successfully!" });
    }

    [HttpDelete("~/api/delete-user", Name = "Delete")]
    public async Task<ActionResult> Delete([FromQuery(Name = "ra")] string ra)
    {
        var userDeleted = await _userService.DeleteUser(ra);
        if (userDeleted == null)
        {
            return NotFound(new ApiResponse { Message = "No items found for this ra!" });
        }

        return Ok(new { Message = "User deleted successfully!" });
    }

    [HttpGet("~/api/get-user-by-ra", Name = "GetByRa")]
    public async Task<ActionResult> GetByRa([FromQuery(Name = "ra")] string ra)
    {
        var user = await _userService.GetUserByRa(ra);
        if (user == null)
        {
            return NotFound(new ApiResponse { Message = "No items found for this ra!" });
        }

        return Ok(user);
    }

    [HttpGet("~/api/get-all-users", Name = "GetAll")]
    public async Task<ActionResult> GetAll()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }
}

public class ApiResponse
{
    public UserDTO? User { get; set; } 
    public string? Message { get; set; }
    
}

