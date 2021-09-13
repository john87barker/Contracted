using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Contracted.Models;
using Contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class JobsController : ControllerBase
    {
    private readonly JobsService _jobsService;

    public JobsController(JobsService jobsService)
    {
      _jobsService = jobsService;
    }


    [HttpPost]
    public async Task<ActionResult<Job>> Create([FromBody] Job newJob)
    {
      try
      {
           Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
      
      Job created = _jobsService.Create(newJob);
      return Ok(created);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<String>> Delete(int id)
    {
        try
        {
             Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _jobsService.Delete(id, userInfo.Id);
        return Ok("deleted");
      }
         catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}