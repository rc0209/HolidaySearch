using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Engine.Repositories
{
    internal interface IHotelsRepository
    {
        Task<IReadOnlyList<Hotel>> SearchHotels(string airport, DateOnly arrivalDate, int nights);
    }
}