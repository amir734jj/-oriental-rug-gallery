using Api.Controllers.Abstracts;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.Models.Products;

namespace API.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    public class RugController : BasicController<Rug>
    {
        private readonly IRugLogic _rugLogic;

        /// <summary>
        /// Constructor dependency injection
        /// </summary>
        /// <param name="rugLogic"></param>
        public RugController(IRugLogic rugLogic)
        {
            _rugLogic = rugLogic;
        }

        protected override IBasicLogic<Rug> BasicLogic()
        {
            return _rugLogic;
        }
    }
}