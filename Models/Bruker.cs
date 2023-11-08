using System.Globalization;

namespace PokeApiNet.Model
{
    public class Bruker
    {
        public int id { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string alder { get; set; }
        public string email { get; set; }
        public string tlf { get; set; }
        public string kjonn { get; set; }
        public int pid { get; set; }
        public string Pokemonkort { get; set; }
    }
}
