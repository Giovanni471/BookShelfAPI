using System;
using System.Collections.Generic;

namespace BookShelf.Models;

public partial class Libri
{
    public int Id { get; set; }

    public string Titolo { get; set; } = null!;

    public string Autore { get; set; } = null!;

    public int AnnoPubblicazione { get; set; }

    public DateTime DataInizio { get; set; }

    public DateTime? DataFine { get; set; }

    public string? Note { get; set; }

    public decimal? RatingPersonale { get; set; }
}
