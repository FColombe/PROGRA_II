// See https://aka.ms/new-console-template for more information




using Repository1.DOMAIN;
using Repository1.SERVICES;

static void Main()
{
    ProdServices serv = new ProdServices();
    List<Product> lst = new List<Product>();

    lst = serv.GetProducts();
    foreach (Product oArticulo in lst)
    {
        Console.WriteLine(oArticulo.ToString());
    }
}
