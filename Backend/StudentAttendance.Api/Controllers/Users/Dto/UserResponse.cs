﻿namespace StudentAttendance.Api.Controllers.Users.Dto;

public class UserResponse
{
    public string? Name { get; set; }
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
    public int? GroupNumber { get; set; }
}