// See https://aka.ms/new-console-template for more information


using Actividad_5.DOMINIO;
using Actividad_5.NEGOCIO.SERVICIOS;

public class Program
{
    static void Main()
    {
        Servicio serv = new Servicio();

        //PRUEBA MARCAS
        //Marca oMarca1 = new Marca()
        //{
        //    Nombre = "Harineros del Norte"
        //};
        //if (serv.AgregarMarca(oMarca1))
        //{
        //    Console.WriteLine("\nMarca agregada");
        //}
        //else
        //{
        //    Console.WriteLine("\nMarca NO agregada");
        //}
        Console.WriteLine("\nLISTA DE MARCAS:\n");
        var marcas = serv.ConsultarMarcas();
        foreach (Marca marca in marcas)
        {
            Console.WriteLine(marca.ToString());
        }

        //PRUEBA TIPOS ARTÍCULOS
        //var tipoArt = new TipoArt()
        //{
        //    Tipo = "GOLOSINAS"
        //};
        //if (serv.AgregarTipo(tipoArt))
        //{
        //    Console.WriteLine("\nTipo de artículo agregado");
        //}
        //else
        //{
        //    Console.WriteLine("\nTipo no agregado");
        //}
        Console.WriteLine("\nTIPOS DE PRODUCTOS: \n");
        var tipos = serv.ConsultarTipos();
        foreach (var tipo in tipos)
        {
            Console.WriteLine(tipo.ToString());
        }

        //PRUEBA ARTICULOS
        //var oArt1 = new Articulo()
        //{
        //    Nombre = "Tallarines",
        //    Tipo = tipos[0],
        //    Marca = marcas[1],                          //Son los index de la lista, no los id
        //    PreUnitario = 1000,
        //};
        //if (serv.AgregarArt(oArt1))
        //{
        //    Console.WriteLine("\nArtículo agregado");
        //}
        //else
        //{
        //    Console.WriteLine("\nArtículo NO agregado");
        //}
        //if (serv.EliminarArt(1))
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
        //    Console.WriteLine("\nCliente nuevo agregado");
        //}
        //else
        //{
        //    Console.WriteLine("\nCliente no agregado");
        //}
        //if (serv.EliminarCliente(1))
        //{
        //    Console.WriteLine("\nCliente eliminado");
        //}
        //else
        //{
        //    Console.WriteLine("\nNo se pudo eliminar el cliente");
        //}
        //Console.WriteLine("\nDETALLE de CLIENTE:" + serv.ConsultarClienteID(2));
        Console.WriteLine("\nLISTA DE CLIENTES: \n");
        var clientes = serv.ConsultarClientes();
        foreach (var cliente in clientes)
        {
            Console.WriteLine(cliente);
        }


        //PRUEBA FORMA PAGO
        //Forma_Pago oForma = new Forma_Pago();
        //oForma.Nombre = "Débito";
        //oForma.Recargo = 5;
        //if (serv.AgregarFP(oForma))
        //{
        //    Console.WriteLine("\nLa forma de pago se ha agregado con éxito.");
        //}
        //else
        //{
        //    Console.WriteLine("\nNo se pudo agregar la forma de pago.");
        //}
        Console.WriteLine("\nFORMAS DE PAGO:\n");
        var formas = serv.ConsultarFP();
        foreach (var forma in formas)
        {
            Console.WriteLine(forma);
        }

        //////PRUEBA FACTURA y DETALLES
        //var detalle1 = new Detalles()
        //{
        //    Articulo = arts[0],
        //    Cantidad = 2
        //};
        //var detalle2 = new Detalles()
        //{
        //    Articulo = arts[1],
        //    Cantidad = 4
        //};

        //var factura1 = new Factura()
        //{
        //    Cliente = clientes[0],
        //    FormaPago = formas[0]
        //};
        //factura1.Detalles.Add(detalle1);
        //factura1.Detalles.Add(detalle2);

        //if (serv.AgregarFactura(factura1))
        //{
        //    Console.WriteLine("\nLa FACTURA se agregó.");
        //}
        //else
        //{
        //    Console.WriteLine("\nNo se pudo agregar la factura.");
        //}
        //if (serv.AnularFactura(1))
        //{
        //    Console.WriteLine("\nLa FACTURA se anuló.");
        ////}
        //else
        //{
        //    Console.WriteLine("\nNo se pudo anular la factura.");
        //}
        Console.WriteLine("\nLISTADO DE FACTURAS:");
        Console.WriteLine("\nNº | FECHA | CLIENTE | FORMA DE PAGO\n");
        var listF = serv.MostrarFacturas();

        foreach (var f in listF)
        {
            Console.WriteLine(f.ToString());
            Console.WriteLine("\nDetalle factura:\n");
            foreach (var d in f.Detalles)
            {
                Console.WriteLine(d);
                Console.WriteLine("Subtotal: $" + d.SubTotal());
            }
            Console.WriteLine("\nMonto Total: $" + f.Total());
        }


    }
}

