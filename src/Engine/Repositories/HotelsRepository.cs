using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Repositories
{
    internal class HotelsRepository : IHotelsRepository
    {
        public Task<IReadOnlyList<Hotel>> SearchHotels(string airport, DateOnly arrivalDate, int nights)
        {
            throw new NotImplementedException();
        }
    }
}
