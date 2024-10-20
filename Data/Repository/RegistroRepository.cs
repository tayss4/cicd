using Fiap.Web.Trafego.Data.Contexts;
using Fiap.Web.Trafego.Models;

namespace Fiap.Web.Trafego.Data.Repository
{
    public class RegistroRepository : IRegistroRepository
    {
        private readonly DatabaseContext _databaseContext;
        public RegistroRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void Create(Registro registro)
        {
            throw new NotImplementedException();
        }

        public void Delete(int registroId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Registro> GetAll()
        {
            throw new NotImplementedException();
        }

        public Registro GetById(int registroId)
        {
            throw new NotImplementedException();
        }

        public void Update(Registro registro)
        {
            throw new NotImplementedException();
        }
    }
}
