using System;
using System.Threading.Tasks;
using Models.Models.Products;

namespace Logic.Interfaces
{
    public interface IRugLogic : IBasicLogic<Rug>
    {
        Task AssignImage(int id, Guid imageId);

        Task UnAssignImage(int id, Guid imageId);
    }
}