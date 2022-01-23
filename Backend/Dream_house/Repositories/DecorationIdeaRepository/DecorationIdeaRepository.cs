using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Data;
using Dream_house.Models;
using Dream_house.Repositories.GenericRepository;

namespace Dream_house.Repositories.DecorationIdeaRepository
{
    public class DecorationIdeaRepository: GenericRepository<DecorationIdea>, IDecorationIdeaRepository
    {
        public DecorationIdeaRepository(DreamHouseContext context): base(context)
        {

        }
    }
}
