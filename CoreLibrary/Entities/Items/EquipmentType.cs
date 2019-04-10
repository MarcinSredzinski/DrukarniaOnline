using CoreLibrary.Common;

namespace CoreLibrary.Entities.Items
{
    public class EquipmentType : BaseEntity
    {
        public string Name { get; set; }
        public string Producent { get; set; }
        public string Size { get; set; }
        public SpecialDateTime SpecialDateTime { get; set; }

        public int CertificateId { get; set; }
        public Certificate Certificate { get; set; }
    }
}
