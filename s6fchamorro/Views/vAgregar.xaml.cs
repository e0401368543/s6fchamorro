using System.Net;

namespace s6fchamorro.Views;

public partial class vAgregar : ContentPage
{
	public vAgregar()
	{
		InitializeComponent();	
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parameters = new System.Collections.Specialized.NameValueCollection();
			parameters.Add("nombre", txtNombre.Text);
			parameters.Add("apellido", txtApellido.Text);
			parameters.Add("edad", txtEdad.Text);
			cliente.UploadValues("http://192.168.100.7/semana6/estudiantesws.php", "POST", parameters);

			Navigation.PushAsync(new Estudiantes());

		}
		catch (Exception ex)
		{

			DisplayAlert("Alerta", ex.Message, "Ok");

		}

	}
}