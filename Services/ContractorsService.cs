using System;
using System.Collections.Generic;
using Contracted.Models;
using Contracted.Repositories;

namespace Contracted.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRepository _repo;

    public ContractorsService(ContractorsRepository repo)
    {
      _repo = repo;
    }

    internal List<Contractor> GetAllContractors()
    {
      return _repo.GetAllContractors();
    }

    internal Contractor GetById(int id)
    {
      Contractor contractor = _repo.GetById(id);
      if (contractor == null)
      {
        throw new Exception("Invalid Id");
      }
      return contractor;
    }

    internal Contractor Create(Contractor newC)
    {
      return _repo.Create(newC);
    }

    internal Contractor Edit(Contractor updatedC)
    {
      Contractor original = GetById(updatedC.Id);
      updatedC.Name = updatedC.Name != null ? updatedC.Name : original.Name;
      
      return _repo.Edit(updatedC);
    }

    internal void Delete(int id)
    {
      Contractor original = GetById(id);
      _repo.Delete(id);
    }
  }
}