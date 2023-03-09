using System.Collections.Generic;

using SQLite;
using MapSched.models;
using System.Threading.Tasks;

namespace MapSched.data
{
    public class SchedDB
    {
        readonly SQLiteAsyncConnection db;

        public SchedDB(string connectionString)
        {
            db = new SQLiteAsyncConnection(connectionString);

            db.CreateTableAsync<Period>().Wait();
        }

        public Task<List<Period>> GetPeriodsAsync()
        {
            return db.Table<Period>().ToListAsync();
        }

        public Task<Period> GetPeriodAsync(int id)
        {
            return db.Table<Period>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SavePeriodAsync(Period period)
        {
            if (period.ID != 0)
            {
                return db.UpdateAsync(period);
            }
            else
            {
                return db.InsertAsync(period);
            }
        }

        public Task<int> DeletePeriodAsync(Period period)
        {
            return db.DeleteAsync(period);
        }
    }
}
