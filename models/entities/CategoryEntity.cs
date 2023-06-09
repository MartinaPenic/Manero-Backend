﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
