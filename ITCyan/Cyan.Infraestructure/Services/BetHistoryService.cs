using Cyan.Domain.Entities;
using Cyan.Infraestructure.Interfaces;
using Cyan.Infraestructure.Data;
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

        public async Task<IEnumerable<BetHistory>> GetList(int pageSize, int pageIndex, string filter)
        {
            var query = _dbContext.BetHistory
                .AsQueryable();

            if (filter.Trim().Length > 1)
            {
               query = query.Where(s=>
               s.Event.Contains(filter) || 
               s.Market.Contains(filter)
               );
            }
            var list = await query
                 .Where(s => !s.IsDeleted)
                 .AsNoTracking()
                 .ToListAsync();

            return list
                .Skip(pageIndex)
                .Take(pageSize);
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
