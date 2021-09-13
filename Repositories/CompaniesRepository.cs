using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contracted.Models;
using Dapper;

namespace Contracted.Repositories
{
  public class CompaniesRepository
  {
    private readonly IDbConnection _db;

    public CompaniesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Company> GetAllCompanies()
    {
      string sql = @"
        SELECT
          *
        FROM companies
        ";
      return _db.Query<Company>(sql).ToList();
    }

    internal Company GetById(int id)
    {
      string sql = @"
      SELECT * FROM companies WHERE id = @id
      ";
      return _db.QueryFirstOrDefault<Company>(sql, new { id });
    }

    internal Company Create(Company newC)
    {
      string sql = @"
      INSERT INTO companies
      (name)
      VALUE
      (@Name)
      SELECT LAST_INSERT_ID();
      ";

      int id = _db.ExecuteScalar<int>(sql, newC);
      return GetById(id);
    }

    internal Company Edit(Company updatedC)
    {
       string sql = @"
      UPDATE companies
      SET 
        name = @name
      WHERE id = @Id;
      ";

      _db.Execute(sql, updatedC);
      return updatedC;
    }

    internal void Delete(int id)
    {
       string sql = "DELETE FROM companies WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}