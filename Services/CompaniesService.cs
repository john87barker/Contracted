using System;
using System.Collections.Generic;
using Contracted.Models;
using Contracted.Repositories;

namespace Contracted.Services
{
  public class CompaniesService
  {
    private readonly CompaniesRepository _repo;

    public CompaniesService(CompaniesRepository repo)
    {
      _repo = repo;
    }

    internal List<Company> GetAllCompanies()
    {
     return _repo.GetAllCompanies();
    }

    internal Company GetById(int id)
    {
      Company company = _repo.GetById(id);
      if (company == null)
      {
        throw new Exception("Invalid Id");
      }
      return company;
    }

    internal Company Create(Company newC)
    {
      return _repo.Create(newC);
    }

    internal Company Edit(Company updatedC)
    {
      Company original = GetById(updatedC.Id);
      updatedC.Name = updatedC.Name != null ? updatedC.Name : original.Name;
      
      return _repo.Edit(updatedC);
    }

    internal void Delete(int id)
    {
      Company original = GetById(id);
      _repo.Delete(id);
    }
  }
}