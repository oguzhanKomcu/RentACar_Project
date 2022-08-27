using Application.Features.BrandFeature.Commands.CreaateBrand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {


            var result = await Mediator.Send(createBrandCommand); // bu command geldiğinde mmediator bununla berbaer
                                                                  // çalışan handlerı bulup işlemleri yaptıracak


            return Created("", result);//kullanıcıya geri dönüşolarak istersek tırank içine api adresinide verebiliriz.
                                       //Result olarakta dto yani response için verilen bilgiler döner.
        }

    }
}
