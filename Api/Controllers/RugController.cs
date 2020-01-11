using System.Threading.Tasks;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Models.Products;

namespace Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    [Route("[controller]")]
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
        
        [HttpGet]
        [Route("Add")]
        public async Task<IActionResult> Add()
        {
            return View(new Rug());
        }
        
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddHandler(Rug rug)
        {
            await _rugLogic.Save(rug);

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            var rug = await _rugLogic.Get(id);
            
            return View(rug);
        }
        
        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateHandler([FromRoute] int id, Rug rug)
        {
            await _rugLogic.Update(rug.Id, rug);

            return RedirectToAction("Index");
        }
    }
}