using Fiap.Web.Trafego.Models;

namespace Fiap.Web.Trafego.Data.Repository
{
    public interface IRegistroRepository
    {
        IEnumerable<Registro> GetAll();
        Registro GetById(int registroId);
        void Create(Registro registro);
        void Update(Registro registro);
        void Delete(int registroId);
    }
}
