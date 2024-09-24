namespace BackArticulos.MODELS
{
    public class Marca
    {
        public int idMarca { get; set; }
        public string Nombre { get; set; }

        public Marca()
        {
            idMarca = 0;
            Nombre = string.Empty;
        }
        public override string ToString()
        {
            return idMarca + " - " + Nombre;
        }
    }
}
