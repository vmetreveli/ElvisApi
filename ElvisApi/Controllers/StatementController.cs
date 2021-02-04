using ElvisApi.Database.Entities;
using ElvisApi.Models;
using ElvisApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ElvisApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatementController : ControllerBase
    {
        private readonly IStatementService _service;

        public StatementController(IStatementService service)
        {
            this._service = service;
        }

        [HttpPost("{filter}")]
        public PagedResult<StatementModel> GetAll([FromForm] string filter)
        {

            return _service.GetAllStatements(filter);
        }


     
        [HttpGet("GetById/{id}")]
        public Statement GetById(int id)
        {

            return _service.GetStatementById(id);
        }



       
        [HttpGet("index/{str}")]
        public string Index(string str)
        {
            return str;
        }

    }
}
