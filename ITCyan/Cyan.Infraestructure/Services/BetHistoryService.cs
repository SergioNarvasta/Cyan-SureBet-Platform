using Cyan.Domain.Entities;
using Cyan.Infraestructure.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cyan.Infraestructure.Services
{
    public class BetHistoryService : IBetHistoryService
    {
        private readonly AppDbContext _dbContext;
        public BetHistoryService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BetHistory>> GetList()
        {
            return await _dbContext.BetHistory
                 .AsNoTracking()
                 .ToListAsync();
        }

        public async Task<BetHistory> GetById(int Id)
        {
            return await _dbContext.BetHistory
                 .Where(x => x.BetHistoryId == Id && !x.IsDeleted)
                 .AsNoTracking()
                 .FirstAsync();
        }

        public async Task<bool> Create(BetHistory model)
        {
            try
            {
                await _dbContext.BetHistory.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Update(BetHistory model)
        {
            try
            {
                _dbContext.BetHistory.Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Delete(int Id)
        {
            try
            {
                var model = await _dbContext.BetHistory
                 .Where(x => x.BetHistoryId == Id && !x.IsDeleted)
                 .AsNoTracking()
                 .FirstOrDefaultAsync();

                if (model != null)
                {
                    _dbContext.BetHistory.Remove(model);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

    }
}
