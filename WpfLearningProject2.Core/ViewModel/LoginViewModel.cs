

using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfLearningProject2.Core
{
    public class LoginViewModel : BaseViewModel
    {
        #region Private Member

        #endregion




        #region Public Memeber
        public string Email { get; set; }

        public bool LoginIsRunning { get; set; }
        #endregion




        #region Command

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        #endregion



        #region ctor
        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand(async ()=> await RegisterAsync());
        }

        private async Task RegisterAsync()
        {
            // TODO: Go rto register page
            //((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Register;
            await Task.Delay(500);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"> secured string </param>
        /// <returns></returns>
        #endregion
        public async Task LoginAsync(object parameter)
        {
            await RunCommand(() => LoginIsRunning, async () =>
            {
                await Task.Delay(5000);
                var email = Email;
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
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
