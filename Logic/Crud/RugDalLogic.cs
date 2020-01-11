using Dal.Interfaces;
using Logic.Abstracts;
using Logic.Interfaces;
using Models.Models.Products;

namespace Logic.Crud
{
    public class RugDalLogic : BasicLogicAbstract<Rug>, IRugLogic
    {
        private readonly IRugDal _rugDal;

        public RugDalLogic(IRugDal rugDal)
        {
            _rugDal = rugDal;
        }
        
        protected override IBasicDal<Rug> GetBasicCrudDal()
        {
            return _rugDal;
        }
    }
}