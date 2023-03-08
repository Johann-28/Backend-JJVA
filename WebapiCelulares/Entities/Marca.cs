namespace WebapiCelulares.Entities
{
    public class Marca
    {
        public int id { get; set; }
        public string nomber { get; set; }

        public List<Celular> celulares { get; set;}
    }
}
