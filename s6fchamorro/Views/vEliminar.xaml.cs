using s6fchamorro.Models;
using System.Net;
using System.Collections.Specialized;
using System.Text;

namespace s6fchamorro.Views;

public partial class vEliminar : ContentPage
{
    public vEliminar(Estudiante datos)
    {
        InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text= datos.edad.ToString();


    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parameters = new NameValueCollection();
            parameters.Add("codigo", txtCodigo.Text);
            parameters.Add("nombre", txtNombre.Text);
            parameters.Add("apellido", txtApellido.Text);
            parameters.Add("edad", txtEdad.Text);

            // Capturar la respuesta del servidor
            byte[] responseBytes = cliente.UploadValues("http://192.168.100.7/semana6/estudiantesws.php", "PUT", parameters);
            string responseString = Encoding.UTF8.GetString(responseBytes);

            // Mostrar la respuesta del servidor para depuración
            await DisplayAlert("Respuesta del Servidor", responseString, "OK");

            // Navegar a otra página si la actualización fue exitosa
            Navigation.PushAsync(new Estudiantes());
        }
        catch (WebException webEx)
        {
            // Capturar errores de WebClient y mostrar detalles
            using (var stream = webEx.Response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                string errorResponse = reader.ReadToEnd();
                await DisplayAlert("Error de WebClient", errorResponse, "OK");
            }
        }
        catch (Exception ex)
        {
            // Capturar otros tipos de excepciones
            await DisplayAlert("Alerta", ex.Message, "OK");
        }

    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parameters = new NameValueCollection();
            parameters.Add("codigo", txtCodigo.Text);
            parameters.Add("nombre", txtNombre.Text);
            parameters.Add("apellido", txtApellido.Text);
            parameters.Add("edad", txtEdad.Text);

            // Capturar la respuesta del servidor
            byte[] responseBytes = cliente.UploadValues("http://192.168.100.7/semana6/estudiantesws.php", "DELETE", parameters);
            string responseString = Encoding.UTF8.GetString(responseBytes);

            // Mostrar la respuesta del servidor para depuración
            await DisplayAlert("Respuesta del Servidor", responseString, "OK");

            // Navegar a otra página si la actualización fue exitosa
            Navigation.PushAsync(new Estudiantes());
        }
        catch (WebException webEx)
        {
            // Capturar errores de WebClient y mostrar detalles
            using (var stream = webEx.Response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                string errorResponse = reader.ReadToEnd();
                await DisplayAlert("Error de WebClient", errorResponse, "OK");
            }
        }
        catch (Exception ex)
        {
            // Capturar otros tipos de excepciones
            await DisplayAlert("Alerta", ex.Message, "OK");
        }


    }
}