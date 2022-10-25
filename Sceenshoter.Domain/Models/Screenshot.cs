using Prism.Mvvm;

namespace Sceenshoter.Domain.Models
{
    public class Screenshot : BindableBase
    {
        private int _id;

        private string? _screenshot;

        private string? _date;

        public int Id { get => _id; set => SetProperty(ref _id, value); }
        public string Base64 { get => _screenshot; set => SetProperty(ref _screenshot, value); }
        public string Date { get => _date; set => SetProperty(ref _date, value); }
    }
}
