using SeverBVSTT.Models;

namespace SeverBVSTT.Models
{
    public abstract class BaseRepository
    {
        protected string connectionString;
        public BaseRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        // khai bao 
    }

}
