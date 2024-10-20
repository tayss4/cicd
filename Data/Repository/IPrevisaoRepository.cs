using Fiap.Web.Trafego.Models;

namespace Fiap.Web.Trafego.Data.Repository
{
    public interface IPrevisaoRepository
    {
        IEnumerable<Previsao> GetAll();
        Previsao GetById(int previsaoId);
        void Create(Previsao previsao);
        void Update(Previsao previsao);
        void Delete(int previsaoId);
    }
}
