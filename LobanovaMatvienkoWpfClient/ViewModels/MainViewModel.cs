using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobanovaMatvienkoWpfClient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ClientsViewModel clientsViewModel { get; }
        public MainViewModel(ClientsViewModel _clientsViewModel)
        {
            clientsViewModel = _clientsViewModel;
        }
    }
    
}
