using BusinessLayer.Dtos;
using BusinessLayer.Mapping;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace BusinessLayer.Services
{
    public class GamingPlatformService
    {
        private readonly UnitOfWork unitOfWork;
        public GamingPlatformService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<GamingPlatform> GetAll()
        {
            return unitOfWork.GamingPlatforms.GetAll();
        }

        public bool AddGamingPlatform(AddGamingPlatformDto gamingPlatform)
        {
            var foundPlatform = unitOfWork.GamingPlatforms.GetAll().Where(x => x.Name == gamingPlatform.Name).FirstOrDefault();
            if (foundPlatform != null)
            {
                return false;
            }
            GamingPlatform newGamingPlatform = gamingPlatform.ToGamingPlatform();
            unitOfWork.GamingPlatforms.Insert(newGamingPlatform);
            unitOfWork.SaveChanges();
            return true;
        }

        public bool RemovePlatformById(IdDto platform)
        {
            var foundPlatform = unitOfWork.GamingPlatforms.GetById(platform.Id);
            if (foundPlatform == null)
            {
                return false;
            }
            //also remove links to gaming pubs
            unitOfWork.GamingPlatforms.Remove(foundPlatform);
            unitOfWork.SaveChanges();
            return true;
        }

        public bool UpdatePlatform(UpdateGamingPlatformDto gamingPlatform)
        {
            var foundPlatform = unitOfWork.GamingPlatforms.GetById(gamingPlatform.Id);
            if (foundPlatform == null)
            {
                return false;
            }
            foundPlatform.Name = gamingPlatform.Name;
            unitOfWork.SaveChanges();
            return true;
        }
    }
}
