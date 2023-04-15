using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Base;
using Repositories.Interface;

namespace Repositories.Repository
{
    public class CadastroContatoRepository : BaseRepositorio<EntityContato>, ICadastroContato
    {
        public readonly DataContext _cadastroContato;
        public CadastroContatoRepository(DataContext dataContex) : base(dataContex)
        {
            _cadastroContato = dataContex;

        }
        public async Task<IEnumerable<EntityContato>> buscarPessoaContato()
        {
            var validacaoCadastro = await _cadastroContato.Set<EntityContato>().Include(x => x.Pessoa).ToListAsync();
            return (validacaoCadastro);
        }

    }
}
