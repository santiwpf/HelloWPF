using System.Windows;

namespace HelloWPF
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var model = new Persona();
            var viewModel = new PersonaViewModel {Model = model};
            var view = new MainWindow {DataContext = viewModel};
            view.Show();
        }
    }
}
