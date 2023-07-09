using System;
using System.Collections.Generic;

namespace Todos.Models;

public partial class Zadaci
{
    public int Id { get; set; }

    public string NazivZadatka { get; set; } = null!;

    public byte[] Stanje { get; set; } = null!;
}
