using Prism.Mvvm;

namespace Sceenshoter.Domain.Models
{
    public class Screenshot : BindableBase
    {
        private Guid _id;

        private string? _screenshot;

        private DateTime? _createDate;

        public Guid Id { get => _id; set => SetProperty(ref _id, value); }
        public string? Base64 { get => _screenshot; set => SetProperty(ref _screenshot, value); }
        public DateTime? CreateDate { get => _createDate; set => SetProperty(ref _createDate, value); }
    }
}
