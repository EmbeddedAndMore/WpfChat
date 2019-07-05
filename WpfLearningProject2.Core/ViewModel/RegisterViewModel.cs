using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfLearningProject2.Core.ViewModel;

namespace WpfLearningProject2.Core
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Private Member

        #endregion




        #region Public Memeber
        public string Email { get; set; }

        public bool RegisterIsRunning { get; set; }
        #endregion




        #region Command

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        #endregion



        #region ctor
        public RegisterViewModel()
        {
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await RegisterAsync(parameter));
            LoginCommand = new RelayCommand(async ()=> await LoginAsync());
        }

        private async Task LoginAsync()
        {
            // TODO: Go rto register page
            IoC.Get<ApplicationViewModel>().GoToPage(DataModels.ApplicationPage.Login);
            //((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Register;
            await Task.Delay(500);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"> secured string </param>
        /// <returns></returns>
        #endregion
        public async Task RegisterAsync(object parameter)
        {
            await RunCommand(() => RegisterIsRunning, async () =>
            {
                await Task.Delay(5000);
               
            });
            //int a, b;
            //await RunCommand(()  =>  5 + 6 > 0, async () =>
            //{
            //    await Task.Delay(5000);
            //    var email = Email;
            //    var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            //});

        }
    }
}
