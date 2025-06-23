using Microsoft.AspNetCore.Mvc;

namespace Semestrovka.Controllers;

[Controller]
public class AdminController : Controller
{
    
    [HttpGet("Admin")]
    public async Task<IActionResult> GetAdmin()
    {
        return View("Adminindex");
    }
}