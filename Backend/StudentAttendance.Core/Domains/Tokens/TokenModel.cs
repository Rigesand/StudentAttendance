﻿namespace StudentAttendance.Core.Domains.Tokens;

public class TokenModel
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}