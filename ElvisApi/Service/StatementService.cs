using System;
using System.Linq;
using ElvisApi.Database;
using ElvisApi.Database.Entities;
using ElvisApi.Service.Interfaces;
using Newtonsoft.Json;
using ElvisApi.Utils;
using ElvisApi.Models;

namespace ElvisApi.Service
{
    public class StatementService : IStatementService
    {
        private IRepository<Statement> repo;

        public StatementService(IRepository<Statement> repo)
        {
            this.repo = repo;
        }

        public PagedResult<StatementModel> GetAllStatements(string filter)
        {

            try
            {
              
                PageFilter obj=null;
                IQueryable<Statement> query;

                if (!string.IsNullOrEmpty(filter))
                {
                    obj =  JsonConvert.DeserializeObject<PageFilter>(filter);
                }
             
                query = !string.IsNullOrEmpty(obj?.Title) ? repo.SearchFor(i => i.Title == obj.Title) : repo.GetAll();

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
                return new PagedResult<StatementModel>();
            }
        }

        public Statement GetStatementById(int id)
        {
         return repo.GetById(id);
        }
    }
}
