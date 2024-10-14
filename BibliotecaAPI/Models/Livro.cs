namespace BibliotecaAPI.Models
{
    public class Livro
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public int AnoPublicacao { get; set; }

        public int GeneroID { get; set; }
        public string GeneroNome { get; set; }
        public int AutorID { get; set; }
        public string AutorNome { get; set; }
    }
}
