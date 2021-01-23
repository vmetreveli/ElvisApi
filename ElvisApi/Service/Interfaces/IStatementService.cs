using System;
using System.Linq;
using ElvisApi.Database.Entities;
using ElvisApi.Models;

namespace ElvisApi.Service.Interfaces
{
    public interface IStatementService
    {
        PagedResult<Statement> GetAllStatements(string filter);
        Statement GetStatementById(int id);
    }
}
