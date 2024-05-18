using Microsoft.AspNetCore.Mvc;
using Application.Contracts;
using Application.DTOs;

namespace WebApi.API.Controllers;

[ApiController]
[Route("[controller]")] 

public class GroupController : ControllerBase
{
    private readonly ILogger<GroupController> _logger;
    private readonly IGroupServices _groupService;


    public GroupController(ILogger<GroupController> logger, IGroupServices groupService)
    {
        _logger = logger;
        _groupService = groupService;
    }


    [HttpGet(Name = "GetAllGroups")] 
    public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroups()
    {
        try 
        {
            var groups = await _groupService.GetGroups();
            return Ok(groups);
        }     
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{groupId}", Name = "GetGroupById")]
    public async Task<IActionResult> GetGroupByIdAsync(long groupId)
    {
        try
        {
            var group = await _groupService.GetGroupById(groupId);
            return Ok(group);
           
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex);
        }
    }


    [HttpPost]
    public async Task<IActionResult> NewGroupAsync([FromBody] GroupDTO groupDto)
    {
        try 
        {
            var newGroup = await _groupService.CreateGroup(groupDto);
            return Ok(newGroup);
        }     
        catch (Exception ex)
        {
           _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }


    [HttpPut("{groupId}")]
    public async Task<IActionResult> UpdateGroupAsync(int groupId, [FromBody] GroupDTO groupDto)
    {
        try
        {
            await _groupService.UpdateGroup(groupDto);
            return Ok();
        }
        catch (Exception ex)
        {
           _logger.LogError(ex.Message);
           return BadRequest(ex.Message);
        }
    }


    [HttpDelete("{groupId}")]
    public async Task<IActionResult> DeleteGroupAsync(int groupId)
    {
        try
        {
            await _groupService.DeleteGroup(groupId);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

}

   