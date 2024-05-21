using DapperCache.Models;

namespace DapperCache.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario> ObterUsuarioPorIdAsync(int id);
}
