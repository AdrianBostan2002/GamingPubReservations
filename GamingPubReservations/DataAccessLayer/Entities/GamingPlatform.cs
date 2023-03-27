using DataAccessLayer.Enums;

namespace DataAccessLayer.Entities
{
    public class GamingPlatform
    {
        public GamingPlatformType Type { get; set; }

        public bool IsAvailable { get; set; }

        public GamingPlatform() { }

        public GamingPlatform(GamingPlatformType type, bool isAvailable)
        {
            Type = type;
            IsAvailable = isAvailable;
        }
    }
}