using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LINQTask.Models;

[Table("EmployeeLog", Schema = "sales")]
public partial class EmployeeLog
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Action { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ActionDate { get; set; }
}
