using Crocheto_0._2.DTO;
using Crocheto_0._2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Crocheto_0._2.ViewsModels
{
    public class CrochetViewModel : INotifyPropertyChanged
    {
        private List<CrochetDTO> _crochets;
        private CrochetService _crochetService;

        public event PropertyChangedEventHandler? PropertyChanged;

        public CrochetViewModel()
        {
            _crochetService = new CrochetService();
            LoadData();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Subtitle { get; set; }
        public string StatusText { get; set; }
        public byte[] PdfFile { get; set; }
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged();

                LoadData();
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }


        public async Task LoadData()
        {
            IsLoading = true;
            try
            {
                var allCrochets = await _crochetService.GetAll();

                Crochets = string.IsNullOrEmpty(SearchText)
                    ? allCrochets
                    : allCrochets.Where(c => c.Title.Contains(SearchText)).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error load data: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        public List<ImageSource> ImageSources
        {
            get
            {
                var imageSources = new List<ImageSource>();

                foreach (var crochet in Crochets)
                {
                    if (!string.IsNullOrEmpty(crochet.Image))
                    {
                        // Convertir la cadena Base64 de nuevo a una imagen
                        byte[] imageBytes = Convert.FromBase64String(crochet.Image);
                        imageSources.Add(ImageSource.FromStream(() => new MemoryStream(imageBytes)));
                    }
                }

                return imageSources;
            }
        }

        public List<CrochetDTO> Crochets
        {
            get { return _crochets; }
            set
            {
                _crochets = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




        public async void ShareCard(CrochetDTO crochet)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = crochet.Title + "\n" + crochet.Description,
                Title = "Share Crochet"
            });
        }

        public async void Download(CrochetDTO crochet)
        {
            if (crochet.PdfFile == null)
            {
                MessagingCenter.Send(this, "Error", "No PDF file available for this item.");
                return;
            }

            var file = Path.Combine(FileSystem.CacheDirectory, crochet.Title + ".pdf");
            File.WriteAllBytes(file, crochet.PdfFile);
            await Launcher.OpenAsync(new OpenFileRequest
            {
                File = new ReadOnlyFile(file)
            });
        }


    }


}
