using ElvisApi.Database.Entities;
using ElvisApi.Models;

namespace ElvisApi.Service.Interfaces
{
    public interface IStatementService
    {
        PagedResult<StatementModel> GetAllStatements(string filter);
        Statement GetStatementById(int id);
    }
}
