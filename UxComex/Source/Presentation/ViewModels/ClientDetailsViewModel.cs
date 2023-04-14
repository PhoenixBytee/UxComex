namespace UxComex.Source.Presentation.ViewModels
{
    public class ClientDetailsViewModel
    {
        public ClientViewModel Client { get; set; }
        public List<AddressViewModel> Addresses { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
