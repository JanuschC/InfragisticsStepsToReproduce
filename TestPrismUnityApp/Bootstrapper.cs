using Microsoft.Practices.Unity;
using Prism.Unity;
using TestPrismUnityApp.Views;
using System.Windows;

namespace TestPrismUnityApp
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}
