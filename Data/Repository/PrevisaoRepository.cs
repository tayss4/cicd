using Fiap.Web.Trafego.Data.Contexts;
using Fiap.Web.Trafego.Models;

namespace Fiap.Web.Trafego.Data.Repository
{
    public class PrevisaoRepository : IPrevisaoRepository
    {
        private readonly DatabaseContext _databaseContext;
        public PrevisaoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void Create(Previsao previsao)
        {
            throw new NotImplementedException();
        }

        public void Delete(int previsaoId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Previsao> GetAll()
        {
            throw new NotImplementedException();
        }

        public Previsao GetById(int previsaoId)
        {
            throw new NotImplementedException();
        }

        public void Update(Previsao previsao)
        {
            throw new NotImplementedException();
        }
    }
}
