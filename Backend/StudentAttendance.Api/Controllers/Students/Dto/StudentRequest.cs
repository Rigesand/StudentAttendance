using System.ComponentModel.DataAnnotations;

namespace StudentAttendance.Api.Controllers.Students.Dto;

public class StudentRequest
{
    [Required] 
    public string Name { get; set; } = null!;
    [Required] 
    [EmailAddress] 
    public string Email { get; set; } = null!;

    public int GroupNumber { get; set; }
}