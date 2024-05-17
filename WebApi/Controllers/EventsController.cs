using Microsoft.AspNetCore.Mvc;
using CliniCareApp.Business;
using CliniCareApp.Models;
using Microsoft.AspNetCore.Cors;

namespace WebApi.API.Controllers;

[ApiController]
[Route("[controller]")] 

public class EventsController : ControllerBase
{
    private readonly ILogger<EventsController> _logger;
    private readonly IEventsService _patientService;


    public EventsController(ILogger<EventsController> logger, IEventService eventService)
    {
        _logger = logger;
        _eventService = EventService;
    }


    [HttpGet(Name = "GetAllEvents")] 
    public ActionResult<IEnumerable<Events>> GetAllEvents([FromQuery] EventQueryParameters eventQueryParameters)
    {
        if (!ModelState.IsValid)  {return BadRequest(ModelState); } 

        try 
        {
            var events = _eventService.GetAllEvents(eventQueryParameters);
            
                if (events == null || !events.Any())
                    {
                        return NotFound("No hay eventos disponibles.");
                    }
                    
            return Ok(events);
        }     
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpGet("{eventId}", Name = "GetEventById")]
    public IActionResult GetEvent(int eventId)
    {
        try
        {
            var event = _eventService.GetEventById(eventId);
            return Ok(event);
           
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"No existe eventos con el Id {Id}");
        }
    }
}

   