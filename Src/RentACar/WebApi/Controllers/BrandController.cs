using Application.Features.BrandFeature.Commands.CreaateBrand;
using Application.Features.BrandFeature.Models;

using Application.Features.BrandFeature.Queries.GetListBrand;
using Core.Application.Requests;
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
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand) //POST OPERASYONLARINDA BODYDEN OKUDUYGUMUZ İÇİN FROMBODY
        {


            var result = await Mediator.Send(createBrandCommand); // bu command geldiğinde mmediator bununla berbaer
                                                                  // çalışan handlerı bulup işlemleri yaptıracak


            return Created("", result);//kullanıcıya geri dönüşolarak istersek tırank içine api adresinide verebiliriz.
                                       //Result olarakta dto yani response için verilen bilgiler döner.



        }


        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest) // GET OPERASYONLARINDA QUERYDEN OKUDUGUMUZ İÇİN FROMQUERY
        {
            //İlk önce pagerequest olarak aldık sonrasında gelen sonucu getlistbrandqueye döndürdük..

            GetListBrandQuery getListBrandQuery = new() { PageRequest= pageRequest};
            BrandListModel result = await Mediator.Send(getListBrandQuery);
            return Ok(result);
        }


        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById([FromRoute] GetByIdBrandQuery getByIdBrandQuery) // direk url üzerinden okuma yapılacağı için fromroute
        //{


        //    var brand = await Mediator.Send(getByIdBrandQuery);
        //    return Ok(brand);
        //}

    }
}
