using System;
using Contracted.Models;
using Contracted.Repositories;

namespace Contracted.Services
{
  public class JobsService
  {
    private readonly JobsRepository _repo;

    public JobsService(JobsRepository repo)
    {
      _repo = repo;
    }

    internal Job Create(Job newJob)
    {
      return _repo.Create(newJob);
    }



    internal void Delete(int id, string userId)
    {
        // Not needed just trying to do what mark did...
    //   Job deadJob = GetById(id);
    //   if(deadJob.ContractorId != userId)

        _repo.Delete(id);
    }

    private Job GetById(int id)
    {
      Job found = _repo.GetById(id);
      if(found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
  }
}