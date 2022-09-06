using Module6HW4.Models;
using Module6HW4.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module6HW4.Interfaces
{
    public interface ITeapotService
    {
        public Task<List<Teapot>> GetTeapots();

        public Task<Teapot> GetTeapotById(Guid id);

        public Task AddTeapot(TeapotViewModel teapotModel);

        public Task EditTeapotById(Guid id, TeapotViewModel teapotModel);

        public Task DeleteTeapotById(Guid id);
    }
}
