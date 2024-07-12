using Newtonsoft.Json;
using s6fchamorro.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace s6fchamorro.Views;

public partial class Estudiantes : ContentPage
{
	private const string Url = "http://192.168.100.7/semana6/estudiantesws.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Models.Estudiante> est;
	public Estudiantes()
	{
		InitializeComponent();
		mostrar();
	}

	public async void mostrar()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Models.Estudiante> mostrar =JsonConvert.DeserializeObject<List<Models.Estudiante>>(content);
		est= new ObservableCollection<Models.Estudiante>(mostrar);
		listestudiante.ItemsSource=est;
	}

    private void btnAgregarEstudiante_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Views.vAgregar());

    }

    private void listestudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var objetosEstudiante=(Estudiante)e.SelectedItem;
		Navigation.PushAsync(new vEliminar(objetosEstudiante));

    }
}