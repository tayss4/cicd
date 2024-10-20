using Fiap.Web.Trafego.Models;

namespace Fiap.Web.Trafego.Data.Repository
{
    public interface ICruzamentoRepository
    {
        IEnumerable<Cruzamento> GetAll();
        Cruzamento GetById(int cruzamentoId);
        void Create(Cruzamento cruzamento);
        void Update(Cruzamento cruzamento);
        void Delete(int cruzamentoId);
    }
}
