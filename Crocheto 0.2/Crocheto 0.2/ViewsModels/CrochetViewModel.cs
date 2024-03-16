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

        public async Task LoadData()
        {
            try
            {
                Crochets = await _crochetService.GetAll();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar datos: {ex.Message}");
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
                Title = "Compartir Crochet"
            });
        }

        public async void Download(CrochetDTO crochet)
        {
            var file = Path.Combine(FileSystem.CacheDirectory, crochet.Title + ".pdf");
            File.WriteAllBytes(file, crochet.PdfFile);
            await Launcher.OpenAsync(new OpenFileRequest
            {
                File = new ReadOnlyFile(file)
            });
        }

    }


}
