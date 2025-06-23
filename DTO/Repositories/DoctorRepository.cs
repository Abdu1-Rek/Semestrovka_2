using DTO.Models;
using Microsoft.EntityFrameworkCore;

namespace DTO.Repositories;

public class DoctorRepository
{
    private readonly ApplicationDbContext _context;
    
    public DoctorRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Doctor>> GetAllAsync()
    {
        return await _context.Doctors.ToListAsync();
    }
    
    public async Task<Doctor> GetByIdAsync(int id)
    {
        return await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<Doctor> CreateAsync(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();
        return doctor;
    }
    
    public async Task<Doctor> UpdateAsync(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
        await _context.SaveChangesAsync();
        return doctor;
    }
    
    public async Task<Doctor> DeleteAsync(Doctor doctor)
    {
        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();
        return doctor;
    }
}