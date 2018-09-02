using System;
using System.ComponentModel.DataAnnotations;

namespace Promelectro.Api.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateCreate { get; set; }
        public int? RoleId { get; set; }
        public string Name { get; set; }
    }
}