using Fiap.Web.Trafego.Data.Contexts;
using Fiap.Web.Trafego.Models;

namespace Fiap.Web.Trafego.Data.Repository
{
    public class HorarioPicoRepository : IHorarioPicoRepository
    {
        private readonly DatabaseContext _databaseContext;
        public HorarioPicoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void Create(HorarioPico horarioPico)
        {
            throw new NotImplementedException();
        }

        public void Delete(int horarioPicoid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HorarioPico> GetAll()
        {
            throw new NotImplementedException();
        }

        public HorarioPico GetById(int horarioPicoId)
        {
            throw new NotImplementedException();
        }

        public void Update(HorarioPico horarioPico)
        {
            throw new NotImplementedException();
        }
    }
}
