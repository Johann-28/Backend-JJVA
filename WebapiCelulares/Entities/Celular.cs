using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace WebapiCelulares.Entities
{
    public class Celular
    {
        public int id { get; set; }
        public int precio { get; set; }
        public string modelo { get; set; }
        public string descripcion { get; set; }
        public int id_marca { get; set; }

        [JsonIgnore]
        public Marca marca { get; set; }   
    }
}
