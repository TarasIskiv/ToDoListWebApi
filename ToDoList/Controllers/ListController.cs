using Application.DTO;
using Application.Interfaces;
using Application.TokenData.Active;
using Application.TokenData.JWT;
using Application.Validations;
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
            var userId = token.UserTokenValidation();
            _noteService.Create(noteDto, userId);
            return Ok();
        }

        [HttpDelete("remove/{id}")]
        public ActionResult DeleteNote([FromHeader] string token,[FromRoute] int id)
        {
            var userId = token.UserTokenValidation();

            var allNotesInUser = _noteService.GetAll(userId);
            allNotesInUser.NoteValidation(id);

            _noteService.Delete(id);
            return Ok();
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<NoteDto>> GetAllNotes([FromHeader] string token)
        {
            var userId = token.UserTokenValidation();
            var notes = _noteService.GetAll(userId).ToList();
            return Ok(notes);
        }


        [HttpGet("{id}")]
        public ActionResult<NoteDto> GetNoteById([FromHeader] string token, [FromRoute] int id)
        {
            var userId = token.UserTokenValidation();

            var allNotesInUser = _noteService.GetAll(userId);
            allNotesInUser.NoteValidation(id);

            return Ok(_noteService.GetById(id));
        }

          
        [HttpPut("update")]
        public ActionResult UpdateNote([FromHeader] string token,[FromBody] UpdateNoteDto noteDto)
        {
            var userId = token.UserTokenValidation();

            var allNotesInUser = _noteService.GetAll(userId);
            allNotesInUser.NoteValidation(noteDto.Id);

            _noteService.Update(noteDto);
            return Ok();
        }
    }
}
