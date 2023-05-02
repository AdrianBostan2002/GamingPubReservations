using DataAccessLayer.Enums;

namespace DataAccessLayer.Entities
{
    public class GamingPlatform : BaseEntity
    {
        public GamingPlatformType Type { get; set; }

        public GamingPlatform() { }
    }
}