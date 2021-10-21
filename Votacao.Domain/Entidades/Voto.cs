namespace Votacao.Domain.Entidades
{
    public class Voto
    {
        public long Id { get; private set; }
        public long IdUsuario { get; private set; }
        public long IdFilme { get; private set; }

        public Voto(long id, long idUsuario, long idFilme)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdFilme = idFilme;
        }
    }
}