using Actividad_5.DOMINIO;
using Actividad_5.SERVICIOS.SERVICIOS;

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
        //Marca oMarca2 = new Marca()
        //{
        //    Nombre = "Arcor"
        //};
        //if (serv.AgregarMarca(oMarca2))
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

        ////PRUEBA TIPOS ARTÍCULOS
        //var tipoArt = new TipoArt()
        //{
        //    Tipo = "PASTAS"
        //};
        //if (serv.AgregarTipo(tipoArt))
        //{
        //    Console.WriteLine("\nTipo de artículo agregado");
        //}
        //else
        //{
        //    Console.WriteLine("\nTipo no agregado");
        //}
        //var tipoArt2 = new TipoArt()
        //{
        //    Tipo = "GOLOSINAS"
        //};
        //if (serv.AgregarTipo(tipoArt2))
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
        //    Marca = marcas[0],                          //Son los index de la lista, no los id
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
        //var oArt2 = new Articulo()
        //{
        //    Nombre = "Rodhesia",
        //    Tipo = tipos[1],
        //    Marca = marcas[1],
        //    PreUnitario = 450,
        //};
        //if (serv.AgregarArt(oArt2))
        //{
        //    Console.WriteLine("\nArtículo agregado");
        //}
        //else
        //{
        //    Console.WriteLine("\nArtículo NO agregado");
        //}
        //var oArt3 = new Articulo()
        //{
        //    Nombre = "Moñitos",
        //    Tipo = tipos[0],
        //    Marca = marcas[0],
        //    PreUnitario = 800,
        //};
        //if (serv.AgregarArt(oArt3))
        //{
        //    Console.WriteLine("\nArtículo agregado");
        //}
        //else
        //{
        //    Console.WriteLine("\nArtículo NO agregado");
        //}
        //var oArt4 = new Articulo()
        //{
        //    Nombre = "Tita",
        //    Tipo = tipos[1],
        //    Marca = marcas[1],
        //    PreUnitario = 800,
        //};
        //if (serv.AgregarArt(oArt4))
        //{
        //    Console.WriteLine("\nArtículo agregado");
        //}
        //else
        //{
        //    Console.WriteLine("\nArtículo NO agregado");

        //}
        //if (serv.EliminarArt(4))
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
        //Cliente oCliente2 = new Cliente("María", "Avellaneda", 23456789, 354332167, "Las Magnolias", 1234);
        //Cliente oCliente3 = new Cliente("Tamara", "Iparraguirre", 23456789, 354332167, "Las Magnolias", 1234);
        //if (serv.AgregarCliente(oCliente1))
        //{
        //    Console.WriteLine("\nCliente nuevo agregado");
        //}
        //else
        //{
        //    Console.WriteLine("\nCliente no agregado");
        //}
        //if (serv.AgregarCliente(oCliente2))
        //{
        //    Console.WriteLine("\nCliente nuevo agregado");
        //}
        //else
        //{
        //    Console.WriteLine("\nCliente no agregado");
        //}
        //if (serv.AgregarCliente(oCliente3))
        //{
        //    Console.WriteLine("\nCliente nuevo agregado");
        //}
        //else
        //{
        //    Console.WriteLine("\nCliente no agregado");
        //}
        //if (serv.EliminarCliente(3))
        //{
        //    Console.WriteLine("\nCliente eliminado");
        //}
        //else
        //{
        //    Console.WriteLine("\nNo se pudo eliminar el cliente");
        //}
        //Console.WriteLine("\nDETALLE de CLIENTE:" + serv.ConsultarClienteID(2));
        //Console.WriteLine("\nLISTA DE CLIENTES: \n");
        //var clientes = serv.ConsultarClientes();
        //foreach (var cliente in clientes)
        //{
        //    Console.WriteLine(cliente);
        //}


        ////PRUEBA FORMA PAGO
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
        //Forma_Pago oForma1 = new Forma_Pago();
        //oForma1.Nombre = "Efectivo";
        //oForma1.Recargo = 0;
        //if (serv.AgregarFP(oForma1))
        //{
        //    Console.WriteLine("\nLa forma de pago se ha agregado con éxito.");
        //}
        //else
        //{
        //    Console.WriteLine("\nNo se pudo agregar la forma de pago.");
        //}
        //Console.WriteLine("\nFORMAS DE PAGO:\n");
        //var formas = serv.ConsultarFP();
        //foreach (var forma in formas)
        //{
        //    Console.WriteLine(forma);
        //}

        ////////PRUEBA FACTURA y DETALLES
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
        //var detalle3 = new Detalles()
        //{
        //    Articulo = arts[2],
        //    Cantidad = 1
        //};
        //var detalle4 = new Detalles()
        //{
        //    Articulo = arts[0],
        //    Cantidad = 1
        //};

        //var factura1 = new Factura()
        //{
        //    Cliente = clientes[0],
        //    FormaPago = formas[0]
        //};
        //factura1.Detalles.Add(detalle1);
        //factura1.Detalles.Add(detalle2);

        //var factura2 = new Factura()
        //{
        //    Cliente = clientes[1],
        //    FormaPago = formas[1]
        //};
        //factura2.Detalles.Add(detalle1);
        //factura2.Detalles.Add(detalle2);
        //factura2.Detalles.Add(detalle3);

        //if (serv.AgregarFactura(factura1))
        //{
        //    Console.WriteLine("\nLa FACTURA se agregó.");
        //}
        //else
        //{
        //    Console.WriteLine("\nNo se pudo agregar la factura.");
        //}
        //if (serv.AgregarFactura(factura2))
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
        //}
        //else
        //{
        //    Console.WriteLine("\nNo se pudo anular la factura.");
        //}
        
        //Console.WriteLine("\nCONSULTAR TODAS LAS FACTURAS:");
        //Console.WriteLine("\nNº |  FECHA  |   CLIENTE   |  FORMA DE PAGO  |  ESTADO\n");
        //var listF = serv.MostrarFacturas();
        //foreach (var f in listF)
        //{
        //    Console.WriteLine(f.ToString());
        //    Console.WriteLine("\nDetalle factura:\n");
        //    foreach (var d in f.Detalles)
        //    {
        //        Console.WriteLine(d);
        //        Console.WriteLine("Subtotal: $" + d.SubTotal());
        //    }
        //    Console.WriteLine("\nMonto Total: $" + f.Total() + "\n");
        //}
        //var facturaID = serv.MostrarFacturaID(2);
        
        //Console.WriteLine("\nCONSULTAR FACTURA POR ID:\nNº |  FECHA  |   CLIENTE   |  FORMA DE PAGO  |  ESTADO\n" + facturaID);
        //foreach (var d in facturaID.Detalles)
        //{
        //    Console.WriteLine(d);
        //    Console.WriteLine("Subtotal: $" + d.SubTotal());
        //}
        //Console.WriteLine("\nMonto Total: $" + facturaID.Total());

        //Console.WriteLine("\nCONSULTAR FACTURAS ANULADAS:\nNº |  FECHA  |   CLIENTE   |  FORMA DE PAGO  |  ESTADO\n");
        //var lstAnuladas = serv.MostrarFacturaEstado("false");
        //foreach (var f in lstAnuladas)
        //{
        //    Console.WriteLine(f.ToString());
        //    Console.WriteLine("\nDetalle factura:\n");
        //    foreach (var d in f.Detalles)
        //    {
        //        Console.WriteLine(d);
        //        Console.WriteLine("Subtotal: $" + d.SubTotal());
        //    }
        //    Console.WriteLine("\nMonto Total: $" + f.Total() + "\n");
        //}
    }
}

