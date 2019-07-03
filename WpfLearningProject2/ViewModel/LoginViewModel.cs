

using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfLearningProject2.DataModels;

namespace WpfLearningProject2
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
        #endregion



        #region ctor
        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"> secured string </param>
        /// <returns></returns>
        #endregion
        public async Task Login(object parameter)
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
