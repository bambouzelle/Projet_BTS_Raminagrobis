using Raminagrobis.WPF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.WPF.ViewModels
{
    public class MainWindowsViewModel : BaseViewModel
    {
        private BaseViewModel _content;
        public BaseViewModel Content
        {
            get => _content;
            set { _content = value; }
        }

        public Command MySuperButtonCommand { get; private set; }

#pragma warning disable CS8618 // Le champ '_content' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
        public MainWindowsViewModel()
#pragma warning restore CS8618 // Le champ '_content' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
        {
            Content = new CartViewModel();
            MySuperButtonCommand = new Command(OnMySuperButtonCommand);
        }

        private void OnMySuperButtonCommand()
        {
            Content = new MemberViewModel();
        }
    }
}