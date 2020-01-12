using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Api.Extensions;
using Api.Middlewares.FileUpload;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.Models.Products;

namespace Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    [Route("[controller]")]
    public class RugController : Controller
    {
        private readonly IRugLogic _rugLogic;

        private readonly IImageUploadLogic _imageUploadLogic;

        public RugController(IRugLogic rugLogic, IImageUploadLogic imageUploadLogic)
        {
            _rugLogic = rugLogic;
            _imageUploadLogic = imageUploadLogic;
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

        [HttpGet]
        [Route("Image/{id}")]
        public async Task<IActionResult> Image([FromRoute] int id)
        {
            var rug = await _rugLogic.Get(id);

            return View(rug);
        }
        
        [FileUpload]
        [HttpPost]
        [Route("Image/{id}/upload")]
        public async Task<IActionResult> ImageUpload([FromRoute] int id, [FromForm] IFormFile file)
        {
            var imageId = await _imageUploadLogic.Upload(await file.ToByteArray(), new Dictionary<string, string>
            {
                ["ProductType"] = ProductTypeEnum.Rug.ToString(),
                ["ProductId"] = id.ToString()
            });

            await _rugLogic.AssignImage(id, imageId);

            return Ok($"Successfully assigned image `{file.FileName}` to rug id: {id}");
        }

        [HttpDelete]
        [Route("Image/{id}/delete/{imageId}")]
        public async Task<IActionResult> ImageDelete([FromRoute] int id, Guid imageId)
        {
            await _imageUploadLogic.Delete(imageId);

            await _rugLogic.UnAssignImage(id, imageId);

            return Ok($"Successfully assigned image `{imageId}` from rug id: {id}");
        }
    }
}