using Application.DTO;
using Application.Interfaces;
using Application.TokenData.Active;
using Application.TokenData.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Controllers
{
    [Route("api/list")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly INoteService _noteService;

        public ListController(INoteService noteService)
        {
            _noteService = noteService;
        }
        
        
        [HttpPost("add/")]
        public ActionResult AddNewNote([FromBody] JObject stuff)
        {
            var token = stuff["token"].ToObject<Token>();
            var noteDto = stuff["note"].ToObject<CreateNoteDto>();
            var currentLoginedUsers = new ActiveLoginedUsers();
            var user = currentLoginedUsers.GetAllLoginedUsers().ToList().Where(x => x.Token == token.token).FirstOrDefault();

            if(user == null)
            {
                return NotFound();
            }

            _noteService.Create(noteDto, user.Id);
            return Ok();
        }

        [HttpDelete("remove/{id}")]
        public ActionResult DeleteNote([FromHeader] string token,[FromRoute] int id)
        {
            var currentLoginedUsers = new ActiveLoginedUsers();
            var user = currentLoginedUsers.GetAllLoginedUsers().ToList().Where(x => x.Token == token).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            var note = _noteService.GetAll(user.Id).ToList().Where(x => x.Id == id);
            if(note == null)
            {
                return NotFound();
            }

            _noteService.Delete(id);
            return Ok();
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<NoteDto>> GetAllNotes([FromHeader] string token)
        {
            var currentLoginedUsers = new ActiveLoginedUsers();
            var user = currentLoginedUsers.GetAllLoginedUsers().ToList().Where(x => x.Token == token).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            var notes = _noteService.GetAll(user.Id).ToList();
            return Ok(notes);
        }


        [HttpGet("{id}")]
        public ActionResult<NoteDto> GetNoteById([FromHeader] string token, [FromRoute] int id)
        {
            var currentLoginedUsers = new ActiveLoginedUsers();
            var user = currentLoginedUsers.GetAllLoginedUsers().ToList().Where(x => x.Token == token).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            var note = _noteService.GetAll(user.Id).ToList().Where(x => x.Id == id);
            if(note == null)
            {
                return NotFound();
            }

            return Ok(_noteService.GetById(id));
        }

          
        [HttpPut("update")]
        public ActionResult UpdateNote([FromBody] UpdateNoteDto noteDto)
        {
            _noteService.Update(noteDto);
            return Ok();
        }
    }
}
