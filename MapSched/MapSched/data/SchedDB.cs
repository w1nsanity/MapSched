using System.Collections.Generic;

using SQLite;
using MapSched.models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using static Android.InputMethodServices.Keyboard;
using Java.Util;
using System.Linq;
using Android.Views;
using System;

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
            return db.Table<Period>().OrderBy(x => x.start_time).ToListAsync();
            //return db.Table<Period>().ToListAsync();
        }

        public Task<Period> GetPeriodAsync(int id)
        {
            return db.Table<Period>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<List<Period>> GetPeriodsByDayOfWeekAsync(string dow)
        {
            return db.Table<Period>().Where(i => i.day_of_week == dow).ToListAsync();
        }

        public Task<List<Period>> GetPeriodsByDOWnWNAsync(string dow, string wn)
        {
            return db.Table<Period>().Where(i => i.day_of_week == dow && i.week_number == wn).OrderBy(i => i.start_time).ToListAsync();
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

        public Task<List<Period>> Search(string search)
        {
            //return db.Table<Period>().Where(i => i.title.StartsWith(search)).ToListAsync();
            return db.Table<Period>().Where(i => i.title.Contains(search)).ToListAsync();
            //return db.Table<Period>().Where(i => search.Any(i.title.Contains)).ToListAsync();
        }
    }
}
