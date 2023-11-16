using Cyan.Application.Interfaces;
using Cyan.Domain.Entities;
using Cyan.Infraestructure.Interfaces;


namespace Cyan.Application.Services
{
    public class BetHistoryAppService : IBetHistoryAppService
    {
        private readonly IBetHistoryService _betHistoryService;
        public BetHistoryAppService(IBetHistoryService betHistoryService) {
            _betHistoryService = betHistoryService;
        }

        public async Task<List<BetHistory>> GetList()
        {
            return await _betHistoryService.GetList();
        }

        public async Task<BetHistory> GetById(int Id)
        {
            return await _betHistoryService.GetById(Id);
        }

        public async Task<bool> Create(BetHistory model)
        {
            return await _betHistoryService.Create(model);
        }

        public async Task<bool> Update(BetHistory model)
        {
            return await _betHistoryService.Update(model);
        }

        public async Task<bool> Delete(int Id)
        {
            return await _betHistoryService.Delete(Id);
        }
    }
}
