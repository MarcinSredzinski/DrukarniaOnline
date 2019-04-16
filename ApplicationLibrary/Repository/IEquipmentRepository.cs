using CoreLibrary.Entities.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLibrary.Repository
{
    public interface IEquipmentRepository : IRepositoryBase<Equipment>
    {
        Task<IEnumerable<Equipment>> FindAllWithDetailsAsync();
        new Task<Equipment> GetDetailsAsync(int id);
        new Task<Equipment> GetDetailsAsync(int? id);
    }
}
