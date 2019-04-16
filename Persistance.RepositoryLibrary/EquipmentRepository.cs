using ApplicationLibrary.Repository;
using CoreLibrary.Entities.Items;
using Microsoft.EntityFrameworkCore;
using PersistenceLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.RepositoryLibrary
{
    public class EquipmentRepository : RepositoryBase<Equipment>, IRepositoryBase<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(DrukarniaDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Equipment>> FindAllWithDetailsAsync()
        {
            return await _dbContext.Set<Equipment>().Include(e => e.Type).ToListAsync<Equipment>();
        }
        public new async Task<Equipment> GetDetailsAsync(int id)
        {
            return await _dbContext.Set<Equipment>().Include(e => e.Type).FirstOrDefaultAsync(i => i.Id == id);
        }
        public new async Task<Equipment> GetDetailsAsync(int? id)
        {
            if (int.TryParse(id.ToString(), out int certainId))
            {
                return await _dbContext.Set<Equipment>().Include(e => e.Type).FirstOrDefaultAsync(i => i.Id == certainId);
            }
            else
            {
                return null;
            }
        }

    }
}
