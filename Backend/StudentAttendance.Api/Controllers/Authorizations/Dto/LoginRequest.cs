﻿using System.ComponentModel.DataAnnotations;

namespace StudentAttendance.Api.Controllers.Authorizations.Dto;

public class LoginRequest
{
    [Required] 
    public string Email { get; set; } = null!;
    [Required] 
    public string Password { get; set; } = null!;
}