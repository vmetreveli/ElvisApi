﻿using ElvisApi.Database.Entities;
using ElvisApi.Models;

namespace ElvisApi.Service.Interfaces
{
    public interface IStatementService
    {
        PagedResult<StatementModel> GetAllStatements(PageFilter filter);
        Statement GetStatementById(int id);
    }
}
