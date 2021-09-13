using System;
using System.Data;
using Contracted.Models;
using Dapper;

namespace Contracted.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Job Create(Job newJob)
    {
      string sql = @"
      INSERT INTO jobs
      (companyId, contractorId)
      VALUES
      (@CompanyId, @ContractorId);
      SELECT LAST_INSERT_ID();
      ";
      newJob.Id = _db.ExecuteScalar<int>(sql, newJob);
      return newJob;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM jobs WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }

    internal Job GetById(int id)
    {
      string sql = "SELECT * FROM jobs WHERE id = @id";
      return _db.QueryFirstOrDefault<Job>(sql, new { id });
    }
  }
}