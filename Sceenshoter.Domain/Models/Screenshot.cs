
namespace Sceenshoter.Domain.Models
{
    public class Screenshot 
    {
        public Guid Id { get; set; }
        public string? Base64 { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
