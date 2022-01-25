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
        
        
        [HttpPost("add")]
        public ActionResult AddNewNote([FromHeader] string token, [FromBody] CreateNoteDto noteDto)
        {
            //var token = dto.Token;
            //var noteDto = dto.note;
            var currentLoginedUsers = new ActiveLoginedUsers();
            var user = currentLoginedUsers.GetAllLoginedUsers().ToList().Where(x => x.Token == token).FirstOrDefault();

            if (user == null)
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

            var note = _noteService.GetAll(user.Id).ToList().Where(x => x.Id == id).FirstOrDefault();
            if(note == null)
            {
                return NotFound();
            }

            return Ok(_noteService.GetById(id));
        }

          
        //change
        [HttpPut("update")]
        public ActionResult UpdateNote([FromHeader] string token,[FromBody] UpdateNoteDto noteDto)
        {
            var currentLoginedUsers = new ActiveLoginedUsers();
            var user = currentLoginedUsers.GetAllLoginedUsers().ToList().Where(x => x.Token == token).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            var note = _noteService.GetAll(user.Id).ToList().Where(x => x.Id == noteDto.Id).FirstOrDefault();
            if(note == null)
            {
                return NotFound();
            }



            _noteService.Update(noteDto);
            return Ok();
        }
    }
}
