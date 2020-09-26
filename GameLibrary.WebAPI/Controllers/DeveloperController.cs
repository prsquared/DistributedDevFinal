using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLibrary.EntityFrameworkDataAccess;
using GameLibrary.Logic;
using GameLibrary.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperLibrary.WebAPI.Controllers
{
    [Route("api/gamelibrary/developer/v1")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private DeveloperLogic _logic;
        public DeveloperController()
        {
            EFGenericRepository<DeveloperPoco> repo = new EFGenericRepository<DeveloperPoco>();
            _logic = new DeveloperLogic(repo);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<DeveloperPoco>), 200)]
        public ActionResult GetAllDeveloper()
        {
            return Ok(_logic.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(DeveloperPoco), 200)]
        public ActionResult GetDeveloper(Guid id)
        {
            DeveloperPoco poco = _logic.Get(id);
            if (poco != null)
            {
                return Ok(poco);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult PostDeveloper([FromBody] DeveloperPoco[] pocos)
        {
            _logic.Create(pocos);
            return Ok();
        }

        [HttpPut]
        public ActionResult PutDeveloper([FromBody] DeveloperPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteDeveloper([FromBody] DeveloperPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
