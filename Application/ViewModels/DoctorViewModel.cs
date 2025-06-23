using DTO.Models;

namespace Application.ViewModels;

public class DoctorViewModel : ViewModel
{
    public List<Doctor> Doctors { get; set; }
}