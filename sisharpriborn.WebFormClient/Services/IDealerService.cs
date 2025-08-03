using sisharpriborn.ASPCoreCilent.Models;

namespace sisharpriborn.ASPCoreCilent.Service
{
    public interface IDealerService
    {
        Task<IEnumerable<Dealer>> GetDealerAsync();
        Task<Dealer> GetDealerByIdAsync(string id);
        Task<Dealer> CreateDealerAsync(DealerInsert dealerInsert);
        Task<Dealer> UpdateDealerAsync(DealerUpdate dealerUpdate);
        Task DeleteDealerAsync(string id);
    }
}
