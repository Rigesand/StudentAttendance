namespace StudentAttendance.Api.Controllers.Attendances.Dto;

public class FilterDate : Filter
{
    public DateTimeOffset Data { get; set; }
}