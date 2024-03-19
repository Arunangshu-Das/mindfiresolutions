using System;
using System.Collections.Generic;

namespace PracCrudLayerMvcCore.DAL.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public int? Salaryamt { get; set; }
}
