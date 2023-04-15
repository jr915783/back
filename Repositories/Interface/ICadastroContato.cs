using Domain.Entities;
using Repositories.Base;

namespace Repositories.Interface
{
    public interface ICadastroContato: IBaseRepository<EntityContato>
    {
        public Task<IEnumerable<EntityContato>> buscarPessoaContato();
    }
    
}
