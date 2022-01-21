﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Models;

namespace Dream_house.Services.HomeService
{
    public interface IHomeService
    {
        IEnumerable<Home> GetAllHomes();
        Home GetHomeById(Guid id);
        void CreateHome(Home home);
        void UpdateHome(Home home);
        void DeleteHome(Home home);
    }
}