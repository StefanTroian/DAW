using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Models;
using Dream_house.Repositories.HomeRepository;

namespace Dream_house.Services.HomeService
{
    public class HomeService: IHomeService
    {
        public IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public IEnumerable<Home> GetAllHomes()
        {
            return (IEnumerable<Home>)_homeRepository.GetAll();
        }

        public Home GetHomeById(Guid id)
        {
            return _homeRepository.FindById(id);
        }

        public void CreateHome(Home home)
        {
            _homeRepository.Create(home);
            _homeRepository.Save();
        }

        public void UpdateHome(Home home)
        {
            _homeRepository.Update(home);
            _homeRepository.Save();
        }
        public void DeleteHome(Home home)
        {
            _homeRepository.Delete(home);
            _homeRepository.Save();
        }
    }
}
