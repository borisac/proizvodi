using ListaProzivoda.Models;

namespace ListaProzivoda.Repositories.EF
{
    public class ProizvodRepository : GenericRepository<Proizvod>
    {
        public ProizvodRepository(ProizvodiEntities context) : base(context)
        {
        }
    }
}