using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contracted.Models;
using Dapper;

namespace Contracted.Repositories
{
  public class ContractorsRepository
  {
    private readonly IDbConnection _db;

    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Contractor> GetAllContractors()
    {
      string sql = @"
        SELECT
          *
        FROM contractors
        ";
      return _db.Query<Contractor>(sql).ToList();
    }

   

    internal Contractor GetById(int id)
    {
      string sql = @"
      SELECT * FROM contractors WHERE id = @id
      ";
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }

    internal Contractor Create(Contractor newC)
    {
      string sql = @"
      INSERT INTO contractors
      (name)
      VALUE
      (@Name)
      SELECT LAST_INSERT_ID();
      ";

      int id = _db.ExecuteScalar<int>(sql, newC);
      return GetById(id);
    }

    internal Contractor Edit(Contractor updatedC)
    {
      string sql = @"
      UPDATE contractors
      SET 
        name = @name
      WHERE id = @Id;
      ";

      _db.Execute(sql, updatedC);
      return updatedC;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM contractors WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}