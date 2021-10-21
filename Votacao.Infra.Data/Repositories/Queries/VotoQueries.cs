namespace Votacao.Infra.Data.Repositories.Queries
{
    public static class VotoQueries
    {
        public static string Inserir = @"INSERT INTO votos(IdUsuario, IdFilme) VALUES (@IdUsuario, @IdFilme); 
                                            SELECT LAST_INSERT_ID();";

        public static string Excluir = @"DELETE FROM votos WHERE Id=@Id;";

        public static string Listar = @"SELECT v.Id, u.IdUsuario, u.Nome, u.Login, 
                                        f.IdFilme, f.Titulo, f.Diretor FROM votos v 
                                        INNER JOIN filmes f ON v.IdFilme = f.IdFilme
                                        INNER JOIN usuarios u ON v.IdUsuario = u.IdUsuario;";

        public static string Obter = @"SELECT v.Id, u.IdUsuario, u.Nome, u.Login, 
                                        f.IdFilme, f.Titulo, f.Diretor FROM votos v 
                                        INNER JOIN filmes f ON v.IdFilme = f.IdFilme
                                        INNER JOIN usuarios u ON v.IdUsuario = u.IdUsuario
                                        WHERE v.Id=@Id;";

        public static string CheckId = @"SELECT Id as Id FROM votos WHERE Id=@Id;";
    }
}