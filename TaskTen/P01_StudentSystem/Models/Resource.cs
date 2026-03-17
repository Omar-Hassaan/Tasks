using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Models
{
    internal class Resource
    {
        public int ResourceId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [Unicode(false)]
        public string Url { get; set; }
        
        public ResourceType ResourceType { get; set; }
        
        public int CourseId { get; set; }
        
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
    }
}
