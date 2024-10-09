using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctions.Application.Lots
{
    public interface ILotRepository
    {
        public Task<IEnumerable<Lot>> GetAllAsync(CancellationToken cancellationToken);
        public Task CreateAsync(Lot lot, CancellationToken cancellationToken);
        public Task ChangeAsync(Guid lotId, string name, DateTime dateStart, DateTime dateEnd, CancellationToken cancellationToken);
        public Task CancelAsync(Guid lotId, CancellationToken cancellationToken);
    }
}
