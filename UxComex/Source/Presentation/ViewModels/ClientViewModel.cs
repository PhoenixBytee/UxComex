using System.ComponentModel.DataAnnotations;

namespace UxComex.Source.Presentation.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [StringLength(30)]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }
        [StringLength(15)]
        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo Telefone é obrigatório")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [StringLength(14)]
        public string Cpf { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateddAt { get; set; }
    }
}
