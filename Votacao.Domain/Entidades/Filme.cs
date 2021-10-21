namespace Votacao.Domain.Entidades
{
    public class Filme
    {
        public long IdFilme { get; private set; }
        public string Titulo { get; private set; }
        public string Diretor { get; private set; }

        public Filme(long idFilme, string titulo, string diretor)
        {
            IdFilme = idFilme;
            Titulo = titulo;
            Diretor = diretor;
        }

        public void SetId(long id)
        {
            IdFilme = id;
        }
    }
}