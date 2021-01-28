using System;
using System.Linq;
using ElvisApi.Database;
using ElvisApi.Database.Entities;
using ElvisApi.Service.Interfaces;
using Newtonsoft.Json;
using ElvisApi.Utils;
using ElvisApi.Models;
using Microsoft.Extensions.Logging;

namespace ElvisApi.Service
{
    public class StatementService : IStatementService
    {
        private readonly IRepository<Statement> repo;
        private readonly ILogger _logger;

        public StatementService(IRepository<Statement> repo, ILogger<StatementService> logger)
        {
            this.repo = repo;
            _logger = logger;
        }

        public PagedResult<StatementModel> GetAllStatements(string filter)
        {
            try
            {
              _logger.LogInformation($"GetAllStatements:{filter}");
                PageFilter obj=null;

                if (!string.IsNullOrEmpty(filter))
                {
                    obj =  JsonConvert.DeserializeObject<PageFilter>(filter);
                }
             
                var query = !string.IsNullOrEmpty(obj?.Title) ? repo.SearchFor(i => i.Title == obj.Title) : repo.GetAll();

                var result = query.Select(i =>new StatementModel
                {
                  Id  = i.Id,
                  Img  = i.Img,
                  Description  = i.Description,
                  Phone  = i.Phone,
                  Title = i.Title,
                  Link  = "<a href = 'https://localhost:9001/home/details/" +
                  i.Id +
                  "' class= 'btn btn-white'> <i class= 'entypo-plus'></i> ნახვა </a>"
                }).AsQueryable().GetPaged((int)obj.PageIndex, (int)obj.PageSize);

                return result;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return new PagedResult<StatementModel>();
            }
        }

        public Statement GetStatementById(int id)
        {
            
         return repo.GetById(id);
        }
    }
}
