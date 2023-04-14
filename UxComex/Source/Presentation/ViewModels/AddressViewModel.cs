using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace UxComex.Source.Presentation.ViewModels
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        [StringLength(30)]
        [Display(Name = "Rua")]
        [Required(ErrorMessage = "O campo Rua é obrigatório")]
        public string Street { get; set; }
        [StringLength(30)]
        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "O campo Cidade é obrigatório")]
        public string City { get; set; }
        [StringLength(2)]
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O campo Estado é obrigatório")]
        public string State { get; set; }
        [StringLength(9)]
        [Display(Name = "Cep")]
        [Required(ErrorMessage = "O campo Cep é obrigatório")]
        public string ZipCode { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateddAt { get; set; }
    }
}
