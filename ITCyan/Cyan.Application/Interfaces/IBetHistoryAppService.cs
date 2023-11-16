using Cyan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyan.Application.Interfaces
{
    public interface IBetHistoryAppService
    {
        Task<bool> Create(BetHistory model);
        Task<bool> Delete(int Id);
        Task<BetHistory> GetById(int Id);
        Task<List<BetHistory>> GetList();
        Task<bool> Update(BetHistory model);
    }
}
