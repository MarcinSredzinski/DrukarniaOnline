using System.Collections.Generic;
using System.Threading.Tasks;
using CoreLibrary.Entities.Items;

namespace ApplicationLibrary.Repository
{
    public interface IEquipmentTypeRepository : IRepositoryBase<EquipmentType>
    {
        Task<IEnumerable<EquipmentType>> FindAllWithDetailsAsync();
        new Task<EquipmentType> GetDetailsAsync(int id);
        new Task<EquipmentType> GetDetailsAsync(int? id);
    }
}