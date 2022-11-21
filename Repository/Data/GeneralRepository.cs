using API_dan_JWT.Context;

namespace API_dan_JWT.Repository.Data
{
    public class GeneralRepository<T1, T2>
    {
        private MyContext myContext;

        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
    }
}