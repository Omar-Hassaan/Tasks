using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Models
{
    [PrimaryKey(nameof(StudentId), nameof(CourseId))]
    internal class StudentCourse
    {
        public int StudentId { get; set; }
        
        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }
        
        public int CourseId { get; set; }
        
        [ForeignKey(nameof(CourseId))]  
        public Course Course { get; set; }
    }
}
