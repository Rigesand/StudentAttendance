﻿namespace StudentAttendance.Api.Controllers.Attendances.Dto;

public class FilterTimeSpan : Filter
{
    public DateTimeOffset BeginDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
}