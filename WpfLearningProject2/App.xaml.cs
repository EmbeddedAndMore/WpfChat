using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfLearningProject2.Core;

namespace WpfLearningProject2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Bind all required view model
            IoC.Setup();

            // show main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }
    }
}
