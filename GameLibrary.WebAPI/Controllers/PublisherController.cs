using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLibrary.EntityFrameworkDataAccess;
using GameLibrary.Logic;
using GameLibrary.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.WebAPI.Controllers
{
    [Route("api/gamelibrary/publisher/v1")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private PublisherLogic _logic;
        public PublisherController()
        {
            EFGenericRepository<PublisherPoco> repo = new EFGenericRepository<PublisherPoco>();
            _logic = new PublisherLogic(repo);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PublisherPoco>), 200)]
        public ActionResult GetAllPublishers()
        {
            return Ok(_logic.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PublisherPoco), 200)]
        public ActionResult GetPublisher(Guid id)
        {
            PublisherPoco poco = _logic.Get(id);
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
        public ActionResult PostPublisher([FromBody] PublisherPoco[] pocos)
        {
            _logic.Create(pocos);
            return Ok();
        }

        [HttpPut]
        public ActionResult PutPublisher([FromBody] PublisherPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeletePublisher([FromBody] PublisherPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
