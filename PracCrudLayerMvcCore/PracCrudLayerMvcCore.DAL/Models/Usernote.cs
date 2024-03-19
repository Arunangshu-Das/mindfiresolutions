using System;
using System.Collections.Generic;

namespace PracCrudLayerMvcCore.DAL.Models;

public partial class Usernote
{
    public int Id { get; set; }

    public string? Noteid { get; set; }

    public string? Note { get; set; }

    public string? Notetype { get; set; }

    public DateTime? Datetimes { get; set; }
}
