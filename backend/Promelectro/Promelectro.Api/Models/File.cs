using System;

namespace Promelectro.Api.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int? PostId { get; set; }
        public DateTime DateLoad { get; set; }
    }
}