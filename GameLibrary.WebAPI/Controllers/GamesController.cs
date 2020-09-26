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
    [Route("api/gamelibrary/games/v1")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private GameLogic _logic;
        public GamesController()
        {
            EFGenericRepository<GamePoco> repo = new EFGenericRepository<GamePoco>();
            _logic = new GameLogic(repo);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GamePoco>), 200)]
        public ActionResult GetAllGames()
        {
            return Ok(_logic.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(GamePoco), 200)]
        public ActionResult GetGame(Guid id)
        {
            GamePoco poco = _logic.Get(id);
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
        public ActionResult PostGame([FromBody] GamePoco[] pocos)
        {
            _logic.Create(pocos);
            return Ok();
        }

        [HttpPut]
        public ActionResult PutGame([FromBody] GamePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteGame([FromBody] GamePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
