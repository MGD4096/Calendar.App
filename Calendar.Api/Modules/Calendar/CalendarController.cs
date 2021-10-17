using Calendar.Application.CalendarEvents.GetCalendarEventQuery;
using Calendar.Application.Calendars.ChangeNameAndDescriptionCommand;
using Calendar.Application.Calendars.CreateNewCalendarCommand;
using Calendar.Application.Calendars.GetCalendarQuery;
using Calendar.Application.Calendars.GetCalendarsForUserQuery;
using Calendar.Application.Calendars.RemoveCalendarCommand;
using Calendar.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Api.Modules.Calendar
{
    [ApiController]
    [Route("api/Calendar")]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarModule _calendarModule;

        public CalendarController(ICalendarModule calendarModule)
        {
            _calendarModule = calendarModule;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get([FromRoute]Guid userId)
        {
            var calendar=await _calendarModule.ExecuteQueryAsync(new GetCalendarsForUserQuery(
                userId
                ));
            return Ok(calendar);
        }
        [HttpGet("/Details/{CalendarId}")]
        public async Task<IActionResult> Put([FromRoute]Guid calendarId)
        {
            var calendar=await _calendarModule.ExecuteQueryAsync(new GetCalendarQuery(
                calendarId
                ));
            return Ok(calendar);
        }
        [HttpPut("{CalendarId}")]
        public async Task<IActionResult> Put([FromRoute]Guid calendarId,[FromForm]CreateCalendarRequest request)
        {
            await _calendarModule.ExecuteCommandAsync(new ChangeNameAndDescriptionCommand(
                request.CalendarName,
                request.CalendarDescription,
                calendarId
                ));
            return Ok();
        }
        [HttpPut("")]
        public async Task<IActionResult> Add([FromForm]CreateCalendarRequest request)
        {
            await _calendarModule.ExecuteCommandAsync(new CreateNewCalendarCommand(
                request.CalendarName,
                request.CalendarDescription,
                request.Owner,
                request.IsPublic,
                request.IsRemoved,
                request.EventsCanBeModifiedBySubscriber
                ));
            return Ok();
        }
        [HttpDelete("{CalendarId}")]
        public async Task<IActionResult> Delete([FromQuery] RemoveCalendarRequest request)
        {
            await _calendarModule.ExecuteCommandAsync(new RemoveCalendarCommand(request.CalendarId));
            return Ok();
        }
    }
}
