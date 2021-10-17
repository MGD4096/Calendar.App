using Calendar.Application.CalendarEvents.AddCalendarEventCommand;
using Calendar.Application.CalendarEvents.ChangeEventDatesCommand;
using Calendar.Application.CalendarEvents.ChangeMainAttributesCommand;
using Calendar.Application.CalendarEvents.GetCalendarEventQuery;
using Calendar.Application.CalendarEvents.GetCalendarEventsForCalendarQuery;
using Calendar.Application.CalendarEvents.RemoveEventCommand;
using Calendar.Application.Calendars.CreateNewCalendarCommand;
using Calendar.Application.Calendars.RemoveCalendarCommand;
using Calendar.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Api.Modules.CalendarEvent
{
    [ApiController]
    [Route("api/CalendarEvent")]
    public class CalendarEventController : ControllerBase
    {
        private readonly ICalendarModule _calendarModule;

        public CalendarEventController(ICalendarModule calendarModule)
        {
            _calendarModule = calendarModule;
        }

        [HttpGet("{CalendarId}")]
        public async Task<IActionResult> Get([FromQuery]Guid id)
        {
            var events=await _calendarModule.ExecuteQueryAsync(new GetCalendarEventsForCalendarQuery(
                id
                ));
            return Ok(events);
        }
        [HttpGet("/Details/{EventId}")]
        public async Task<IActionResult> GetDetails([FromQuery]Guid id)
        {
            var events=await _calendarModule.ExecuteQueryAsync(new GetCalendarEventQuery(
                id
                ));
            return Ok(events);
        }
        [HttpPost("/DateChange")]
        public async Task<IActionResult> ChangeDate([FromForm]ChangeEventDatesRequest request)
        {
            await _calendarModule.ExecuteCommandAsync(new ChangeEventDatesCommand(
                request.startDate,
                request.endDate,
                request.UserId,
                request.EventId
                ));
            return Ok();
        }
        [HttpPost("")]
        public async Task<IActionResult> Edit([FromForm]ChangeMainAttributesRequest request)
        {
            await _calendarModule.ExecuteCommandAsync(new ChangeMainAttributesCommand(
                request.EventName,
                request.EventDescription,
                request.Owner,
                request.EventId
                ));
            return Ok();
        }
        [HttpPut("")]
        public async Task<IActionResult> Add([FromForm] CreateCalendarEventRequest request)
        {
            await _calendarModule.ExecuteCommandAsync(new AddCalendarEventCommand(
                request.EventName,
                request.EventDescription,
                request.CalendarId,
                request.UserId,
                request.IsRemoved,
                request.AllDayEvent,
                request.StartDate,
                request.EndDate,
                request.NotifyBefore
                ));
            return Ok();
        }
        [HttpDelete("")]
        public async Task<IActionResult> Delete([FromForm] RemoveEventRequest request)
        {
            await _calendarModule.ExecuteCommandAsync(new RemoveEventCommand(request.EventId,request.UserId));
            return Ok();
        }
    }
}
