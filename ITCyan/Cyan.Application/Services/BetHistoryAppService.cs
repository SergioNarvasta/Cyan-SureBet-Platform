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

        public async Task<IEnumerable<BetHistory>> GetList(int pageSize, int pageIndex, string filter)
        {
            return await _betHistoryService.GetList(pageSize, pageIndex, filter);
        }

        public async Task<BetHistory> GetById(int Id)
        {
            return await _betHistoryService.GetById(Id);
        }

        public async Task<bool> Create(BetHistory model)
        {
            model.CreateDate = DateTime.Now;
            model.IsDeleted = false;
           
            //Add the current User
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
