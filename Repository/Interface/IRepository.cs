using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API_dan_JWT.Repository.Interface
{
    public interface IRepository<Entity> where Entity : class
    {

        public IEnumerable<Entity> Get();

        public Entity Get(int Id);

        public int Create(Entity entity);

        public int Update(Entity entity);

        public int Delete(int Id);
    }
}
