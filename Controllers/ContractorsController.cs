using System;
using System.Collections.Generic;
using Contracted.Models;
using Contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ContractorsController : ControllerBase
    {
    private readonly ContractorsService _contractorsService;

    public ContractorsController(ContractorsService contractorsService)
    {
      _contractorsService = contractorsService;
    }

    [HttpGet]

    public ActionResult<List<Contractor>> GetAllContractors()
    {
        try
        {
        List<Contractor> contractors = _contractorsService.GetAllContractors();
        return Ok(contractors);
      }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    [HttpPost("{id}")]
    public ActionResult<Contractor> Create([FromBody] Contractor newC)
    {
        try
        {
        Contractor made = _contractorsService.Create(newC);
        return Ok(made);
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Contractor> Edit([FromBody] Contractor updatedC, int id)
    {
        try
        {
        updatedC.Id = id;
        Contractor contractor = _contractorsService.Edit(updatedC);
        return Ok(contractor);
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
        try
        {
        _contractorsService.Delete(id);
        return Ok("deleted");
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }


  }
}