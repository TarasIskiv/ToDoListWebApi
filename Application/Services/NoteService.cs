using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Application.Services
{
    public class NoteService : INoteService
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;

        public NoteService(IMapper mapper, INoteRepository noteRepository)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }

        void INoteService.Create(CreateNoteDto dto, int id)
        {
            if(string.IsNullOrWhiteSpace(dto.Content))
            {
                throw new Exception("Empty Content");
            }

            var note = _mapper.Map<Note>(dto);
            _noteRepository.AddNewNote(note, id);
        }

        void INoteService.Delete(int id)
        {
            var note = _noteRepository.GetNoteById(id);
            if(note == null) throw new Exception("Bad Unique Id");
            _noteRepository.DeleteNote(note);
        }

        IEnumerable<NoteDto> INoteService.GetAll(int id)
        {
            var notes = _noteRepository.GetAllNotes(id);
            var dtos = _mapper.Map<IEnumerable<NoteDto>>(notes);
            return dtos;
        }

        NoteDto INoteService.GetById(int id)
        {
            var note = _noteRepository.GetNoteById(id);
            var result = _mapper.Map<NoteDto>(note);
            return result;
        }

        void INoteService.Update(UpdateNoteDto dto)
        {
            var note = _mapper.Map<Note>(dto);
            _noteRepository.Update(note);
        }
    }
}
