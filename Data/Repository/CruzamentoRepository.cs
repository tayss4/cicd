using Fiap.Web.Trafego.Data.Contexts;
using Fiap.Web.Trafego.Models;

namespace Fiap.Web.Trafego.Data.Repository
{
    public class CruzamentoRepository : ICruzamentoRepository
    {
        private readonly DatabaseContext _databaseContext;
        public CruzamentoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void Create(Cruzamento cruzamento)
        {
            throw new NotImplementedException();
        }

        public void Delete(int cruzamentoId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cruzamento> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cruzamento GetById(int cruzamentoId)
        {
            throw new NotImplementedException();
        }

        public void Update(Cruzamento cruzamento)
        {
            throw new NotImplementedException();
        }
    }
}
