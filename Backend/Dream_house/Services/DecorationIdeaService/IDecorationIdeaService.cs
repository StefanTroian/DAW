using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Models;

namespace Dream_house.Services.DecorationIdeaService
{
    public interface IDecorationIdeaService
    {
        IEnumerable<DecorationIdea> GetAllDecorationIdeas();
        DecorationIdea GetDecorationIdeaById(Guid id);
        void CreateDecorationIdea(DecorationIdea decorationIdea);
        void UpdateDecorationIdea(DecorationIdea decorationIdea);
        void DeleteDecorationIdea(DecorationIdea decorationIdea);
    }
}
