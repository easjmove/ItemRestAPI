using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemLibrary;
using ItemRestAPI.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using ItemRestAPI.AppDbContext;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItemRestAPI.Controllers
{
    [Route("Items")]
    [EnableCors("AllowOnlyGet")]
    [ApiExplorerSettings(GroupName ="v2")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsManager _manager; //= new ItemsManager();

        public ItemsController(ItemContext context)
        {
            _manager = new ItemsManagerDB(context);
        }

        // GET: /Items?contains=wat
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get([FromQuery] string contains)
        {
            IEnumerable<Item> items = _manager.GetAll(contains);
            if (items.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(items);
            }
        }

        // GET /Items/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            Item item = _manager.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }

        // POST /<ItemsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        
        [HttpPost]
        public ActionResult<Item> Post([FromBody] Item item)
        {
            return Ok(_manager.Add(item));
        }

        // PUT /Items/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [DisableCors]
        [HttpPut("{id}")]
        public ActionResult<Item> Put(int id, [FromBody] Item item)
        {
            Item result = _manager.Update(id, item);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        // DELETE /<ItemsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Item> Delete(int id)
        {
            Item result = _manager.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
