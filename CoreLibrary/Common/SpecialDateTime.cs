using CoreLibrary.Entities;

namespace CoreLibrary.Common
{
    public class SpecialDateTime : BaseEntity
    {
        public int Days { get; set; }
        public int Months { get; set; }
        public int Years { get; set; }
    }
}
