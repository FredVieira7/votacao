namespace Votacao.Infra.Data.Repositories.Queries
{
    public static class UsuarioQueries
    {
        public static string Inserir = @"INSERT INTO usuarios(Nome, Login, Senha) VALUES (@Nome, @Login, @Senha); 
                                        Select LAST_INSERT_ID();";

        public static string Atualizar = @"UPDATE usuarios SET Nome=@Nome, Login=@Login, Senha=@Senha where IdUsuario=@Id;";

        public static string Excluir = @"DELETE FROM usuarios WHERE IdUsuario=@Id";

        public static string Listar = @"SELECT IdUsuario, Nome as Nome, Login as Login FROM usuarios;";

        public static string Obter = @"SELECT IdUsuario, Nome as Nome, Login as Login FROM usuarios where IdUsuario=@Id;";

        public static string CheckId = @"SELECT IdUsuario FROM usuarios WHERE IdUsuario=@Id;";

        public static string Autenticar = @"SELECT IdUsuario FROM usuarios WHERE Login=@Login AND Senha=@Senha";
    }
}