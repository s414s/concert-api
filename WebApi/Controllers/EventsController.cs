using Microsoft.AspNetCore.Mvc;
using Application.Contracts;
using Application.DTOs;

namespace WebApi.API.Controllers;

[ApiController]
[Route("[controller]")] 

public class EventController : ControllerBase
{
    private readonly ILogger<EventController> _logger;
    private readonly IEventServices _eventService;


    public EventController(ILogger<EventController> logger, IEventServices eventService)
    {
        _logger = logger;
        _eventService = eventService;
    }


    [HttpGet(Name = "GetAllEvents")] 
    public async Task<ActionResult<IEnumerable<EventDTO>>> GetAllEventsAsync()
    {
        try 
        {
            var events = await _eventService.GetEvents();
            return Ok(events);
        }     
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{eventId}", Name = "GetEventById")]
    public async Task<IActionResult> GetEventByIdAsync(long eventId)
    {
        try
        {
            var e = await _eventService.GetEventById(eventId);
            return Ok(e);
           
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }


    [HttpPost]
    public async Task<IActionResult> NewEventAsync([FromBody] EventDTO eventDto)
    {
        try 
        {
            var e = await _eventService.CreateEvent(eventDto);
            return Ok(e);
        }     
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }


    [HttpPut("{eventId}")]
    public async Task<IActionResult> UpdateEventAsync(long eventId, [FromBody] EventDTO eventDto)
    {
        try
        {
            await _eventService.UpdateEvent(eventId, eventDto);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }


    [HttpDelete("{eventId}")]
    public async Task<IActionResult> DeleteEventAsync(int eventId)
    {
        try
        {
            await _eventService.DeleteEvent(eventId);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }
}

   