

using LobanovaMatvienkoApiHttpClient;
using System.Collections.ObjectModel;



namespace LobanovaMatvienkoWpfClient.ViewModels
{
    public class ClientsViewModel : BaseViewModel
    {
        private ClientHttpClient _httpClient;
        public ClientsViewModel(ClientHttpClient httpClient)
        {
            _httpClient = httpClient;
            GetClients();
        }
        private ObservableCollection<Client> _Clients;
         
        public ObservableCollection<Client> Clients
        {
            get { return _Clients; }
            set { _Clients = value; OnPropertyChanged(); }

        }
        private async void GetClients()
        {
            Clients = new ObservableCollection<Client>(await _httpClient.GetAllAsync());
        }
    }

}
