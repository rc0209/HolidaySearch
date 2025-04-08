using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engine
{
    internal class HolidaySearchEngine
    {
        public async Task<IReadOnlyList<Holiday>> GetHolidays(HolidaySearch criteria)
        {
            ArgumentNullException.ThrowIfNull(criteria);
            return await Task.FromResult(Enumerable.Empty<Holiday>().ToList());
        }
    }
}
