using Application.ViewModels;
using DTO.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Semestrovka.Controllers;

[Controller]
public class DashboardController : Controller
{
    private readonly DoctorRepository _doctorRepository;
    
    
    public DashboardController(DoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }
    
    [Authorize]
    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboard()
    {
        return View("index");
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetIndex()
    {
        return Redirect("dashboard");
    }
    
    [HttpGet("doctors")]
    public async Task<IActionResult> GetDoctor()
    {
        var model = await _doctorRepository.GetAllAsync();
        return View("doctor", new DoctorViewModel(){ Doctors = model});
    }
    
    [HttpGet("appointments")]
    public async Task<IActionResult> GetAppointment()
    {
        return View("appointment");
    }
}