namespace API_dan_JWT.Repository.Interface
{
    public interface IRepository<Entity> where Entity : class
    {

        public List<Entity> Get();

        public Entity Get(int id);

        public int Create(Entity entity);

        public int Update(Entity entity);

        public int Delete( int id);
    }
}
