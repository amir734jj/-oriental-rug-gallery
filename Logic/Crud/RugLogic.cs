using System;
using System.Threading.Tasks;
using Dal.Interfaces;
using Logic.Abstracts;
using Logic.Interfaces;
using Models.Models.Products;

namespace Logic.Crud
{
    public class RugLogic : BasicLogicAbstract<Rug>, IRugLogic
    {
        private readonly IRugDal _rugDal;

        public RugLogic(IRugDal rugDal)
        {
            _rugDal = rugDal;
        }
        
        protected override IBasicDal<Rug> GetBasicCrudDal()
        {
            return _rugDal;
        }

        public async Task AssignImage(int id, Guid imageId)
        {
            await _rugDal.Update(id, rug => rug.Images.Add(imageId));
        }

        public async Task UnAssignImage(int id, Guid imageId)
        {
            await _rugDal.Update(id, rug => rug.Images.Remove(imageId));
        }
    }
}