// See https://aka.ms/new-console-template for more information


using Actividad_5.NEGOCIO.DOMINIO;
using Actividad_5.NEGOCIO.SERVICIOS;

public class Program
{
    static void Main()
    {
        Servicio serv = new Servicio();

        //PRUEBA MARCAS
        //Marca oMarca1 = new Marca()
        //{
        //    Nombre = "Arcor"
        //};
        //if (serv.AgregarMarca(oMarca1))
        //{
        //    Console.WriteLine("Marca agregada");
        //}
        //else
        //{
        //    Console.WriteLine("NO agregado");
        //}
        //Console.WriteLine("LISTA DE MARCAS:");
        Console.WriteLine("LISTA DE MARCAS:\n");
        var marcas = serv.ConsultarMarcas();
        foreach (Marca marca in marcas)
        {
            Console.WriteLine(marca.ToString());
        }

        //PRUEBA TIPOS ARTÍCULOS
        //var tipoArt = new TipoArt()
        //{
        //    Tipo = "PASTAS"
        //};
        //if (serv.AgregarTipo(tipoArt))
        //{
        //    Console.WriteLine("Tipo de artículo agregado");
        //}
        //else
        //{
        //    Console.WriteLine("Tipo no agregado");
        //}
        Console.WriteLine("\nTIPOS DE PRODUCTOS: \n");
        var tipos = serv.ConsultarTipos();
        foreach(var tipo in tipos)
        {
            Console.WriteLine(tipo.ToString());
        }

        //PRUEBA ARTICULOS

        //var oArt1 = new Articulo()
        //{
        //    Nombre = "Tallarines",
        //    Tipo = tipos[5],
        //    Marca = marcas[8],
        //    PreUnitario = 1000,
        //};

        //if (serv.AgregarArt(oArt1))
        //{
        //    Console.WriteLine("Artículo agregado");
        //}
        //else
        //{
        //    Console.WriteLine("Artículo NO agregado");
        //}
        
        //if(serv.EliminarArt(1))
        //{
        //    Console.WriteLine("Artículo eliminado");
        //}
        //else
        //{
        //    Console.WriteLine("Artículo NO eliminado");
        //}

        //Console.WriteLine("DETALLE DEL ARTÍCULO SELECCIONADO: " + serv.ConsultarArtID(1));

        Console.WriteLine("\nLISTA DE ARTÍCULOS:\n");
        var arts = serv.ConsultarArticulos();
        foreach (var art in arts)
        {
            Console.WriteLine(art);
        }


        //PRUEBA CLIENTES

        //Cliente oCliente1 = new Cliente("Pedro", "Pascal", 23456789, 354332167, "Las Magnolias", 1234);
        //if (serv.AgregarCliente(oCliente1))
        //{
        //    Console.WriteLine("Cliente nuevo agregado");
        //}
        //else
        //{
        //    Console.WriteLine("Cliente no agregado");
        //}

        //if (serv.EliminarCliente(1))
        //{
        //    Console.WriteLine("Cliente eliminado");
        //}
        //else
        //{
        //    Console.WriteLine("No se pudo eliminar el cliente");
        //}



        Console.WriteLine("\nLISTA DE CLIENTES: \n");
        var clientes = serv.ConsultarClientes();
        foreach (var cliente in clientes)
        {
            Console.WriteLine(cliente);
        }


        //PRUEBA FORMA PAGO
        //Forma_Pago oForma = new Forma_Pago();
        //oForma.Nombre = "Débito";
        //oForma.Recargo = 2;
        //if (serv.AgregarFP(oForma))
        //{
        //    Console.WriteLine("La forma de pago se ha agregado con éxito.");
        //}
        //else
        //{
        //    Console.WriteLine("No se pudo agregar la forma de pago.");
        //}

        Console.WriteLine("\nFORMAS DE PAGO:\n");
        var formas = serv.ConsultarFP();
        foreach (var forma in formas)
        {
            Console.WriteLine(forma);
        }

        ////PRUEBA DETALLES
        var detalle1 = new Detalles()
        {
            Articulo = arts[0],
            Cantidad = 2
        };



        var factura1 = new Factura()
        {
            Cliente = clientes[0],
            FormaPago = formas[0]
        };
        factura1.Detalles.Add(detalle1);

        if (serv.AgregarFactura(factura1))
        {
            Console.WriteLine("La se agregó.");
        }
        else
        {
            Console.WriteLine("No se pudo agregar la factura.");
        }
    }
}

