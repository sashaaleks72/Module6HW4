using Module6HW4.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module6HW4.Interfaces
{
    public interface IDataProvider
    {
        public Task<List<Teapot>> GetTeapots();

        public Task<Teapot> GetTeapotById(Guid id);

        public Task<int> AddTeapot(Teapot teapot);

        public Task<int> EditTeapot(Teapot teapot);

        public Task<int> DeleteTeapot(Teapot teapot);
    }
}
