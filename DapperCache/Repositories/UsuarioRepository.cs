using Dapper;
using DapperCache.Models;
using DapperCache.Repositories;
using Microsoft.Extensions.Caching.Memory;
using MySql.Data.MySqlClient;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly string _connectionString;
    private readonly IMemoryCache _cache;
    private readonly ILogger<UsuarioRepository> _logger;

    public UsuarioRepository(IConfiguration configuration, IMemoryCache cache, ILogger<UsuarioRepository> logger)
    {
        _connectionString = configuration.GetConnectionString("MySqlConnection");
        _cache = cache;
        _logger = logger;
    }

    public async Task<Usuario> ObterUsuarioPorIdAsync(int id)
    {
        Usuario usuario;
        string cacheKey = $"Usuario_{id}";

        if (!_cache.TryGetValue(cacheKey, out usuario))
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM Usuarios WHERE Id = @Id";
                usuario = await connection.QueryFirstOrDefaultAsync<Usuario>(query, new { Id = id });

                if (usuario != null)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                        SlidingExpiration = TimeSpan.FromMinutes(2)
                    };

                    _cache.Set(cacheKey, usuario, cacheEntryOptions);
                }
            }
        }

        return usuario;
    }
}
