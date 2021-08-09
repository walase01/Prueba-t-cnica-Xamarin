using pruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pruebaTecnica.Services
{
    public interface IDatabaseService
    {
        Task<List<Address>> GetListAddress();
        Task<int> InsertAddress(Address address);
    }
}
