using System;
using System.Collections.Generic;
using Contracted.Models;
using Contracted.Repositories;
using Contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class CompaniesController : ControllerBase
    {
    private readonly CompaniesService _companiesService;

    public CompaniesController(CompaniesService companiesService)
    {
      _companiesService = companiesService;
    }

    [HttpGet]

    public ActionResult<List<Company>> GetAllCompanies()
    {
        try
        {
        List<Company> contractors = _companiesService.GetAllCompanies();
        return Ok(contractors);
      }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    [HttpPost("{id}")]
    public ActionResult<Company> Create([FromBody] Company newC)
    {
        try
        {
        Company made = _companiesService.Create(newC);
        return Ok(made);
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Company> Edit([FromBody] Company updatedC, int id)
    {
        try
        {
        updatedC.Id = id;
        Company contractor = _companiesService.Edit(updatedC);
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
        _companiesService.Delete(id);
        return Ok("deleted");
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }
    }
}