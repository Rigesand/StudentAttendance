﻿using System.ComponentModel.DataAnnotations;

namespace StudentAttendance.Api.Controllers.Tokens.Dto;

public class TokenRequestDto
{
    [Required]
    public string? Token { get; set; }
    [Required]
    public string? RefreshToken { get; set; }
}