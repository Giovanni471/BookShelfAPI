namespace BookShelf.Models.ViewModels
{
    public class LibroViewModel
    {
        public int Id { get; set; }

        public string Titolo { get; set; } = null!;

        public string Autore { get; set; } = null!;

        public int AnnoPubblicazione { get; set; }

        public DateTime DataInizio { get; set; }

        public DateTime? DataFine { get; set; }

        public string? Note { get; set; }

        public decimal? RatingPersonale { get; set; }

        public List<Categorie>? Categorie { get; set; }


        public static LibroViewModel MapLibroToViewModel(Libri libro)
        {
            var model = new LibroViewModel();
            model.Id = libro.Id;
            model.AnnoPubblicazione = libro.AnnoPubblicazione;
            model.Titolo = libro.Titolo;
            model.Autore = libro.Autore;
            model.RatingPersonale = libro.RatingPersonale;
            model.Note = libro.Note;

            model.DataFine = libro.DataFine;
            model.DataInizio = libro.DataInizio;

            return model;
        }

        public static LibroViewModel MapLibroToViewModel(Libri libro, List<Categorie> categories)
        {
            var model = MapLibroToViewModel(libro);

            model.Categorie = categories;
            return model;
        }
    }
}
