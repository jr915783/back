using Data.Context;
using Domain.Entities;
using Repositories.Base;
using Repositories.Interface;

namespace Repositories.Repository
{
    public class CadastroRepository : BaseRepositorio<EntityCadastrosPessoa>, ICadastro
    {
        public readonly DataContext _cadastro;
        public CadastroRepository(DataContext dataContex) : base(dataContex)
        {
            _cadastro = dataContex;           
        }
    }
}
