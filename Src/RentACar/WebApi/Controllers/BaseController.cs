using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {

        //Bir base controller oluştuuryoruz.Çünkü aslında tüm controllerlarda mediator kullanıcağız.Bu da sürekli oluşturulacak ve kontorl edilemeyeceği için bir şartlandırma koyuyoruz
        // Ve bu şekilde mediator nesnesi varsa yenisi oluşturulmuyor.
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;


        //bU fonksiyonu sadece kalıtım alan yerlerde kullanmak istediğimiz için protected yaptık.
        protected  string? GetIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For")) return Request.Headers["X-Forwarded-For"];
            return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }
    }
}