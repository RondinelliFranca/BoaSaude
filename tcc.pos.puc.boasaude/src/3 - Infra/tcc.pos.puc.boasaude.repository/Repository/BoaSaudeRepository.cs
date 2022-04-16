
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using tcc.pos.puc.boasaude.domain.Interface;
using tcc.pos.puc.boasaude.repository.Config;
using Dapper;
using tcc.pos.puc.boasaude.domain.Models;
using tcc.pos.puc.boasaude.domain.ModelView;

namespace tcc.pos.puc.boasaude.repository.Repository
{
    public class BoaSaudeRepository : IBoaSaudeRepository
    {
        private readonly ConfiguracaoDataBase configuracaoDataBase;
        public async Task<List<Associados>> BuscarAssociadosAsync()
        {
            using var connection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=BoaSaude;Trusted_Connection=True");

            try
            {
                var query = @"SELECT *
                                     [Id]
                                    ,[IdEndereco]
                                    ,[IdPlano]
                                    ,[Nome]
                                    ,[DataNascimento]
                                FROM[BoaSaude].[dbo].[Associados]";
                connection.Open();

                return (List<Associados>)await connection.QueryAsync<Associados>(query).ConfigureAwait(false);

            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public async Task<Associados> BuscarAssociadosPorIdAsync(Guid id)
        {
            using var connection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=BoaSaude;Trusted_Connection=True");

            try
            {
                var query = @"SELECT 
                                     [Id]
                                    ,[IdEndereco]
                                    ,[IdPlano]
                                    ,[Nome]
                                    ,[DataNascimento]
                                    ,[cpf]
                                    ,[RG]
                                    ,[NomeMae]
                                    ,[NomePai]
                                FROM[BoaSaude].[dbo].[Associados]
                                Where id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                connection.Open();

                return await connection.QueryFirstAsync<Associados>(query, parameters).ConfigureAwait(false);

            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public async Task<bool> CriarAssociadosAsync(AssociadoViewModel associadoViewModel)
        {
            using var connection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=BoaSaude;Trusted_Connection=True");

            try
            {
                var idEndereco = await CriarEndereco(associadoViewModel.Endereco);

                associadoViewModel.Associados.IdEndereco = idEndereco;
                associadoViewModel.Associados.Id = Guid.NewGuid();

                var sqlAssociados = @"INSERT INTO [dbo].[Associados]
                                                   ([Id]
                                                   ,[IdEndereco]
                                                   ,[IdPlano]
                                                   ,[Nome]
                                                   ,[DataNascimento]
                                                   ,[cpf]
                                                   ,[RG]
                                                   ,[NomeMae]
                                                   ,[NomePai])
                                             VALUES
                                                    (
                                                      @Id
                                                      ,@IdEndereco                                                      
                                                      ,@IdPlano
                                                      ,@Nome
                                                      ,@DataNascimento
                                                      ,@cpf
                                                      ,@RG
                                                      ,@NomeMae
                                                      ,@NomePai
                                                    )";

                connection.Open();

                return await connection.ExecuteAsync(sqlAssociados, associadoViewModel.Associados)
                    .ConfigureAwait(false) > 0;
            }
            catch (Exception exception)
            {
                var a = exception;
                return false;
            }
            finally         
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public async Task<bool> AtualizarAssociadosAsync(Associados associados, Guid idAssociado)
        {
            using var connection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=BoaSaude;Trusted_Connection=True");

            try
            {

                var sqlAssociados = @"UPDATE [dbo].[Associados] 
                                                    SET 
                                                    Nome = @Nome
                                                    ,DataNascimento = @DataNascimento
                                                    ,Cpf = @Cpf
                                                    ,Rg = @Rg
                                                    ,NomeMae = @NomeMae
                                                    ,NomePai = @NomePai
                                                WHERE Id = @Id";

                connection.Open();
                associados.Id = idAssociado;
                
                return await connection.ExecuteAsync(sqlAssociados, associados).ConfigureAwait(false) > 0;

            }
            catch (Exception exception)
            {
                var execp = exception;
                return false;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public async Task<bool> DeletarAssociadoAsync(Guid idAssociado)
        {
            using var connection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=BoaSaude;Trusted_Connection=True");

            try
            {
                var query = @"DELETE FROM [dbo].[Associados] WHERE Id = @idAssociado";
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@idAssociado", idAssociado);

                return await connection.ExecuteAsync(query, parameters).ConfigureAwait(false) > 0;

            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public async Task<List<TipoPlano>> BuscarTipoPlanosAsync()
        {
            using var connection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=BoaSaude;Trusted_Connection=True");

            try
            {
                var query = @"SELECT * FROM [BoaSaude].[dbo].[TipoPlano]";
                connection.Open();

                return (List<TipoPlano>)await connection.QueryAsync<TipoPlano>(query).ConfigureAwait(false);

            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public async Task<List<SituacaoPlano>> BuscarSituacaoPlanoAsync()
        {
            using var connection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=BoaSaude;Trusted_Connection=True");

            try
            {
                var query = @"SELECT * FROM [BoaSaude].[dbo].[SituacaoPlano]"; ;
                connection.Open();

                return (List<SituacaoPlano>)await connection.QueryAsync<SituacaoPlano>(query).ConfigureAwait(false);

            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public async Task<bool> Criar(Plano plano)
        {
            using var connection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=BoaSaude;Trusted_Connection=True");

            try
            {
                var query = @"INSERT INTO [dbo].[Plano]
           ([Id]
           ,[IdSituacaoPlano]
           ,[IdTipoPlano]
           ,[Nome]
           ,[Descricao]
           ,[Odonto]
           ,[Individual])
     VALUES
            (
                @Id, 
                @IdSituacaoPlano, 
                @IdTipoPlano, 
                @Nome, 
                @Descricao, 
                @Odonto, 
                @Individual
            )"; ;
                connection.Open();

                return await connection.ExecuteAsync(query, plano).ConfigureAwait(false) > 0;

            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        private async Task<Guid> CriarEndereco(Endereco endereco)
        {
            endereco.Id = Guid.NewGuid();

            using var connection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=BoaSaude;Trusted_Connection=True");

            try
            {
                var sqlEndereco = @"INSERT INTO [dbo].[Endereco]
                                                       ([Id]
                                                       ,[IdTipoEndereco]
                                                       ,[Lougradouro]
                                                       ,[Numero]
                                                       ,[Bairro]
                                                       ,[Cidade]
                                                       ,[Estado]
                                                       ,[Cep])
                                                 VALUES
                                                        (
                                                          @Id
                                                          ,@IdTipoEndereco
                                                          ,@Lougradouro
                                                          ,@Numero
                                                          ,@Bairro
                                                          ,@Cidade
                                                          ,@Estado
                                                          ,@Cep
                                                        )";

                connection.Open();

                await connection.ExecuteAsync(sqlEndereco, endereco).ConfigureAwait(false);

                return endereco.Id;

            }
            catch (Exception e)
            {
                var a = e;
                return Guid.NewGuid();
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
    }
}
