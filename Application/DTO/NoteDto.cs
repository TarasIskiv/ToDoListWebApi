using System;


namespace Application.DTO
{
    public class NoteDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
