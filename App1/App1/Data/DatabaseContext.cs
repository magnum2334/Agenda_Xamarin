using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App1.Models;
using System.Threading.Tasks;

namespace App1.Data
{
    public class DatabaseContext
    {
  
        readonly SQLiteAsyncConnection _database;

        public DatabaseContext(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Item>().Wait();

        }

        public Task <int> SaveModelAsync<T>(T model, bool isInsert) where T : new()
        {
            if (isInsert != true)
            {
                return _database.UpdateAsync(model);
            }
            else
            {
                return _database.InsertAsync(model);
            }
        }
        public Task<List<User>> ValidateUserModel(string gmail, string pw)
        {
            return _database.QueryAsync<User>("SELECT * FROM User WHERE Gmail = '" + gmail + "' AND Password = '" + pw + "' ");
        }

        public Task<User> GetUserModel(string usr, string pw)
        {
            return _database.Table<User>().Where(i => i.Gmail == usr && i.Password == pw).FirstOrDefaultAsync();

        }
        public Task<List<T>> GetTableModel<T>() where T : new()
        {
            return _database.Table<T>().ToListAsync();
        }

    }
}
