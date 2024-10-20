using Fiap.Web.Trafego.Models;

namespace Fiap.Web.Trafego.Data.Repository
{
    public interface IHorarioPicoRepository
    {
        IEnumerable<HorarioPico> GetAll();
        HorarioPico GetById(int horarioPicoId);
        void Create(HorarioPico horarioPico);
        void Update(HorarioPico horarioPico);
        void Delete(int horarioPicoid);
    }
}
