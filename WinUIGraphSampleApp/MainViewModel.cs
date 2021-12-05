using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace WinUIGraphSampleApp
{
    public class MainViewModel : ObservableObject
    {
        private string _userName;
        private string _email;

        public MainViewModel()
        {
            LoadUserDetailsCommand = new AsyncRelayCommand(LoadUserDetails);
        }

        public async Task LoadUserDetails()
        {
            var graphService = Ioc.Default.GetService<IGraphService>();
            var user = await graphService.GetMyDetailsAsync();
            UserName = user.DisplayName;
            Email = user.Mail;
        }

        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value, nameof(UserName)); }
        }

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value, nameof(Email)); }
        }

        public IAsyncRelayCommand LoadUserDetailsCommand { get; set; }
    }
}
