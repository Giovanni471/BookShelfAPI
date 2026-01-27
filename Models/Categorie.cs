using System;
using System.Collections.Generic;

namespace BookShelf.Models;

public partial class Categorie
{
    public int Id { get; set; }

    public string Descrizione { get; set; } = null!;

    public string DescrizioneEn { get; set; } = null!;
}
