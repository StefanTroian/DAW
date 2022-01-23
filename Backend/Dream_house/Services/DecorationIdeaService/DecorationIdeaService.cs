using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Models;
using Dream_house.Repositories.DecorationIdeaRepository;

namespace Dream_house.Services.DecorationIdeaService
{
    public class DecorationIdeaService : IDecorationIdeaService
    {
        public IDecorationIdeaRepository _decorationIdeaRepository;

        public DecorationIdeaService(IDecorationIdeaRepository decorationIdeaRepository)
        {
            _decorationIdeaRepository = decorationIdeaRepository;
        }
        public IEnumerable<DecorationIdea> GetAllDecorationIdeas()
        {
            return (IEnumerable<DecorationIdea>)_decorationIdeaRepository.GetAll();
        }

        public DecorationIdea GetDecorationIdeaById(Guid id)
        {
            return _decorationIdeaRepository.FindById(id);
        }

        public void CreateDecorationIdea(DecorationIdea decorationIdea)
        {
            _decorationIdeaRepository.Create(decorationIdea);
            _decorationIdeaRepository.Save();
        }

        public void UpdateDecorationIdea(DecorationIdea decorationIdea)
        {
            _decorationIdeaRepository.Update(decorationIdea);
            _decorationIdeaRepository.Save();
        }
        public void DeleteDecorationIdea(DecorationIdea decorationIdea)
        {
            _decorationIdeaRepository.Delete(decorationIdea);
            _decorationIdeaRepository.Save();
        }
    }
}
