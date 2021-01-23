using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElvisApi.Database;
using ElvisApi.Database.Entities;
using ElvisApi.Models;
using ElvisApi.Service.Interfaces;
using ElvisApi.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ElvisApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatementController : ControllerBase
    {
        private IStatementService service;

        public StatementController(IStatementService service)
        {
            this.service = service;
        }

        [HttpPost("GetAll/{filter}")]
        public PagedResult<Statement> GetAll([FromForm] string filter)
        {

            return service.GetAllStatements(filter);
        }


     
        [HttpGet("GetByID/{id}")]
        public Statement GetByID(int id)
        {

            return service.GetStatementById(id);
        }



       
        [HttpGet("index/{str}")]
        public string Index(string str)
        {
            return str;
        }

    }
}
