using System.Threading.Tasks;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Models.Products;

namespace Api.Controllers
{
    public class RugController : Controller
    {
        private readonly IRugLogic _rugLogic;

        public RugController(IRugLogic rugLogic)
        {
            _rugLogic = rugLogic;
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var rugs = await _rugLogic.GetAll();

            return View(rugs);
        }
        
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Add(Rug rug)
        {
            await _rugLogic.Save(rug);

            return RedirectToAction("Index");
        }
    }
}