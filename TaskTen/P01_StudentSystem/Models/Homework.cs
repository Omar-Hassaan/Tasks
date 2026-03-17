using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Models
{
    internal class Homework
    {
        public int HomeworkId { get; set; }

        [Unicode(false)]
        public string Content { get; set; }
        
        public ContentType ContentType { get; set; }
        
        public DateTime SubmissionTime { get; set; }
        
        public int StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }
        
        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
    }
}
