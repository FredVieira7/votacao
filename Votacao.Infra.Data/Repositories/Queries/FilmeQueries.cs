namespace Votacao.Infra.Data.Repositories.Queries
{
    public class FilmeQueries
    {
        
        public static string Inserir = @"INSERT INTO filmes(Titulo, Diretor) VALUES (@Titulo, @Diretor); 
                                        Select LAST_INSERT_ID();";

        public static string Atualizar = @"UPDATE filmes SET Titulo=@Titulo, Diretor=@Diretor where IdFilme=@Id;";

        public static string Excluir = @"DELETE FROM filmes WHERE IdFilme=@Id";

        public static string Listar = @"SELECT IdFilme as Id, Titulo as Titulo, Diretor as Diretor FROM filmes;";

        public static string Obter = @"SELECT IdFilme as Id, Titulo as Titulo, Diretor as Diretor FROM filmes where IdFilme=@Id;";

        public static string CheckId = @"SELECT IdFilme FROM filmes WHERE IdFilme=@Id;";
    }
}