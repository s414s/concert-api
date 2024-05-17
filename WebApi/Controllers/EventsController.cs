using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
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
            return BadRequest(ex);
        }
    }

    [HttpGet("{eventId}", Name = "GetEventById")]
    public IActionResult GetEventById(long eventId)
    {
        try
        {
            var e = _eventService.GetEventById(eventId);
            return Ok(e);
           
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"No existe eventos con el Id {eventId}");
        }
    }


    [HttpPost]
    public IActionResult NewEvent([FromBody] EventDTO eventDto)
    {
        // Verificar si el modelo recibido es válido
        if (!ModelState.IsValid){ return BadRequest(ModelState);}

        if (string.IsNullOrEmpty(eventDto.Name) || string.IsNullOrEmpty(eventDto.ZipCode))

        {
            return BadRequest("Los campos no pueden estar vacíos.");
        }

        try 
        {
            var ev = _eventService.CreateEvent(eventDto);
            return CreatedAtAction(nameof(GetAllEventsAsync), new { eventId = ev.Id }, ev);
        }     
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPut("{eventId}")]
    public IActionResult UpdateEvent(int eventId, [FromBody] EventDTO eventDto)
    {
        if (!ModelState.IsValid)  {return BadRequest(ModelState); } 

        try
        {
            _eventService.UpdateEvent(eventId, eventDto);
            return Ok($"El evento con Id: {eventId} ha sido actualizado correctamente");
        }
        catch (KeyNotFoundException)
        {
           return NotFound();
        }
    }


    [HttpDelete("{eventId}")]
    public IActionResult DeleteEvent(int eventId)
    {
        try
        {
            _eventService.DeleteEvent(eventId);
            return Ok($"El evento con Id: {eventId} ha sido borrado correctamente");
        }
        catch (KeyNotFoundException ex)
        {
            _logger.LogInformation(ex.Message);
            return NotFound();
        }
    }

}

   