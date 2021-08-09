using pruebaTecnica.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace pruebaTecnica.Services
{
    public class DabaseService : IDatabaseService
    {

        private bool _initialized = false;
        private static SQLiteAsyncConnection db;

        public List<Address> ListAddress { get; set; }

        public DabaseService()
        {
            Initialize();
        }

        private async void Initialize()
        {
            try
            {
                _initialized = true;

                if(db != null)
                {
                    return;
                }

                var databaseAddress = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Address.db");
                db = new SQLiteAsyncConnection(databaseAddress);

                await db.CreateTableAsync<Address>();

                ListAddress = await db.Table<Address>().ToListAsync();

            }catch(Exception ex)
            {

            }
        }

        public Task<List<Address>> GetListAddress()
        {
            return db.Table<Address>().ToListAsync();
        }

        public async Task<int> InsertAddress(Address address)
        {
            try
            {
                int result = await db.InsertAsync(address);
                ListAddress = await db.Table<Address>().ToListAsync();
                return result;

            }
            catch(Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}
