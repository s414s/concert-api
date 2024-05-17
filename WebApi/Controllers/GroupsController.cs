using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Application.Contracts;
using Application.DTOs;

namespace WebApi.API.Controllers;

[ApiController]
[Route("[controller]")] 

public class GroupsController : ControllerBase
{
    private readonly ILogger<GroupsController> _logger;
    private readonly IGroupServices _groupService;


    public GroupsController(ILogger<GroupsController> logger, IGroupServices groupService)
    {
        _logger = logger;
        _groupService = groupService;
    }


    [HttpGet(Name = "GetAllGroups")] 
    public ActionResult<IEnumerable<Application.DTOs.GroupDTO>> GetGroups()
    {
        if (!ModelState.IsValid)  {return BadRequest(ModelState); } 

        try 
        {
            var groups = _groupService.GetGroups();
            
                if (groups == null || !groups.Any())
                    {
                        return NotFound("No hay grupos disponibles.");
                    }
                    
            return Ok(groups);
        }     
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpGet("{groupId}", Name = "GetGroupById")]
    public IActionResult GetGroupById(long groupId)
    {
        try
        {
            var group = _groupService.GetGroupById(groupId);
            return Ok(group);
           
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"No existe grupos con el Id {groupId}");
        }
    }


    [HttpPost]
    public IActionResult NewGroup([FromBody] GroupDTO groupDto)
    {
        // Verificar si el modelo recibido es válido
        if (!ModelState.IsValid){ return BadRequest(ModelState);}

        if (string.IsNullOrEmpty(groupDto.Name) || string.IsNullOrEmpty(groupDto.Password))

        {
            return BadRequest("Los campos no pueden estar vacíos.");
        }

        try 
        {
            var group = _groupService.CreateGroup(groupDto);
            return Ok("Grupo creado correctamente");
        }     
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPut("{groupId}")]
    public IActionResult UpdateGroup(int groupId, [FromBody] GroupDTO groupDto)
    {
        if (!ModelState.IsValid)  {return BadRequest(ModelState); } 

        try
        {
            _groupService.UpdateGroup(groupDto);
            return Ok($"El grupo con Id: {groupId} ha sido actualizado correctamente");
        }
        catch (KeyNotFoundException)
        {
           return NotFound();
        }
    }


    [HttpDelete("{groupId}")]
    public IActionResult DeleteGroup(int groupId)
    {
        try
        {
            _groupService.DeleteGroup(groupId);
            return Ok($"El grupo con Id: {groupId} ha sido borrado correctamente");
        }
        catch (KeyNotFoundException ex)
        {
            _logger.LogInformation(ex.Message);
            return NotFound();
        }
    }

}

   