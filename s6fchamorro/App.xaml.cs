using s6fchamorro.Views;

namespace s6fchamorro
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Estudiantes());
        }
    }
}
