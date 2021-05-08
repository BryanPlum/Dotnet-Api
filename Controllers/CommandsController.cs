using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CmdApi.Models;
using CmdiApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CmdApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandContext _context;

        public CommandsController(CommandContext context) => _context = context;

        //or
        // public CommandsController(CommandContext context)
        // {
        //     _context = context;
        // }

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommands()
        {
            return _context.CommandItems;
        }

        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandItem(int id)
        {
            var commandItem = _context.CommandItems.Find(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(commandItem);
        }


        //POST api/commands
        [HttpPost]
        public ActionResult<Command> PostCommandItem(Command command)
        {
            //adicionando o item
            _context.CommandItems.Add(command);

            //salvando as alterações
            _context.SaveChanges();

            return CreatedAtAction("GetCommandItem", new Command { Id = command.Id }, command);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult PutCommandItem(int id, Command command)
        {
            //checking the id
            if (id != command.Id)
            {
                return BadRequest();

            }

            _context.Entry(command).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }


        //DELETE api/commads/{id}
        [HttpDelete("{id}")]
        public ActionResult<Command> DeleteCommandItem(int id)
        {
            var commandItem = _context.CommandItems.Find(id);

            if (commandItem == null)
            {
                return NotFound();
            }

            //Deletando o item
            _context.CommandItems.Remove(commandItem);

            //Salvando alterações
            _context.SaveChanges();

            return commandItem;

        }
    }
}