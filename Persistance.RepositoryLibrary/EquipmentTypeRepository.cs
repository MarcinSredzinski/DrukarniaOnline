using ApplicationLibrary.Repository;
using CoreLibrary.Entities.Items;
using Microsoft.EntityFrameworkCore;
using PersistenceLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.RepositoryLibrary
{
   public class EquipmentTypeRepository : RepositoryBase<EquipmentType>, IReposotoryBase<EquipmentType>
    {
        public EquipmentTypeRepository(DrukarniaDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<EquipmentType>> FindAllWithDetailsAsync()
        {
            return await _dbContext.Set<EquipmentType>().Include(c => c.Certificate).ToListAsync<EquipmentType>();
        }
        public new async Task<EquipmentType> GetDetailsAsync(int id)
        {
            return await _dbContext.Set<EquipmentType>().Include(c => c.Certificate).FirstOrDefaultAsync(i => i.Id == id);
        }
        public new async Task<EquipmentType> GetDetailsAsync(int? id)
        {
            if (int.TryParse(id.ToString(), out int certainId))
            {
                return await _dbContext.Set<EquipmentType>().Include(c=> c.Certificate).FirstOrDefaultAsync(i => i.Id == certainId);
            }
            else
            {
                return null;
            }
        }
    }
}
