using BookShelf.Models.ViewModels;

namespace BookShelf.Models.DapperModels
{
    public class ViewLibriCategorieModel
    {
        public int IdLibro { get; set; }

        public string? Titolo { get; set; }

        public string Autore { get; set; } = null!;

        public int AnnoPubblicazione { get; set; }

        public DateTime DataInizio { get; set; }

        public DateTime? DataFine { get; set; }

        public string? Note { get; set; }

        public decimal? RatingPersonale { get; set; }

        public int IdCategoria { get; set; }

        public string? Descrizione {  get; set; }

        public string? DescrizioneEN { get; set; }



        public static List<LibroViewModel> MapViewToModel(IEnumerable<ViewLibriCategorieModel> viewModelList)
        {
            List<LibroViewModel> listaFinale = new List<LibroViewModel>();

            Dictionary<int, List<Categorie>> DictionaryFInale = new Dictionary<int, List<Categorie>>();
            Dictionary<int, Libri> IdTitoliDictionary = new Dictionary<int, Libri>();

            foreach (var viewModel in viewModelList) 
            {
                if (!DictionaryFInale.ContainsKey(viewModel.IdLibro))
                {
                    DictionaryFInale.Add(viewModel.IdLibro, new List<Categorie>());
                    IdTitoliDictionary.Add(viewModel.IdLibro, new Libri
                    {
                        Id = viewModel.IdLibro,
                        Titolo = viewModel.Titolo,
                        AnnoPubblicazione = viewModel.AnnoPubblicazione,
                        Autore = viewModel.Autore,
                        DataFine = viewModel.DataFine,
                        DataInizio = viewModel.DataInizio,
                        Note = viewModel.Note,
                        RatingPersonale = viewModel.RatingPersonale
                    });
                }

                DictionaryFInale[viewModel.IdLibro].Add(new Categorie()
                {
                    Id = viewModel.IdCategoria,
                    Descrizione = viewModel.Descrizione,
                    DescrizioneEn = viewModel.DescrizioneEN
                });
            }

            foreach ((int idLibro, Libri libro) in IdTitoliDictionary)
            {
                var libroViewModel = LibroViewModel.MapLibroToViewModel(libro, DictionaryFInale[idLibro]);

                listaFinale.Add(libroViewModel);
            }

            return listaFinale;
        }
    }
}
