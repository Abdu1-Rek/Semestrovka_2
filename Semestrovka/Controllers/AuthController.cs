using DTO.Models;

namespace Semestrovka.Controllers;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Controller]
public class AuthController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    
    
    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    [HttpGet("login")]
    public async Task<IActionResult> GetLogin()
    {
        return View("login");
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> PostLogin(string fullname, string password)
    {
        var user = await _userManager.FindByNameAsync(fullname);
    
    
        if (user == null) 
            return Redirect("/register");
    
        var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        
        if (!result.Succeeded) 
            return Redirect("/404");
    
        await _signInManager.SignInAsync(user, isPersistent: true);
    
        return Redirect("/dashboard");
    }
    
    
    [HttpPost("register")]
    public async Task<IActionResult> PostRegister(string fullName, string email, string password)
    {
        var user = new User()
        {
            FullName = fullName,
            UserName = fullName,
            Email = email,
        };
    
        var result = await _userManager.CreateAsync(user, password);
    
        if (!result.Succeeded)
        {
            return Redirect("/register");
        }
    
        return Redirect("/login");
    }
    
    [HttpGet("logout")]
    public async Task<IActionResult> GetLogout()
    {
        await _signInManager.SignOutAsync();
        return Redirect("/login");
    }
}