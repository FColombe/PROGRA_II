// See https://aka.ms/new-console-template for more information


using Actividad_5.NEGOCIO.DOMINIO;
using Actividad_5.NEGOCIO.SERVICIOS;

public class Program
{
    static void Main()
    {
        Servicio serv = new Servicio();
        List<Articulo> lst = new List<Articulo>();

        Console.WriteLine("hola)");

        lst = serv.ConsultarArt();
        foreach (Articulo oArticulo in lst)
        {

            Console.WriteLine(oArticulo.Nombre.ToString());
        }



    }
}

