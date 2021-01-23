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

        public PagedResult<Statement> GetAllStatements(string filter)
        {

            try
            {
                Console.WriteLine(filter);
                PageFilter obj=null;
                IQueryable<Statement> query;

                if (!string.IsNullOrEmpty(filter))
                {
                    obj =  JsonConvert.DeserializeObject<PageFilter>(filter);
                }
             
               if (!string.IsNullOrEmpty(obj?.Title))
                {
                    query = repo.SearchFor(i => i.Title == obj.Title);
                }
                else
                {
                    query = repo.GetAll();
                }

                var result = query.GetPaged((int)obj.PageIndex, (int)obj.PageSize);

                return result;
            }catch(Exception ex)
            {
                return new PagedResult<Statement>();
            }
        }

        public Statement GetStatementById(int id)
        {
         return repo.GetById(id);
        }
    }
}
