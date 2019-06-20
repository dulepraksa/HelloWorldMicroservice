﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelloWorldMicroservice.Models
{
    public class Phrase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Body { get; set; }
        public bool Editing { get; set; }
    }
}