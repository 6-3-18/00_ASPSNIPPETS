using jQuery_AJAX_WebAPI_MVC.Models;
using System;
using System.Web.Http;

namespace jQuery_AJAX_WebAPI_MVC.Controllers
{
    public class AjaxAPIController : ApiController
    {
        [Route("api/AjaxAPI/AjaxMethod")]
        [HttpPost]
        public PersonModel AjaxMethod(PersonModel person)
        {
            person.DateTime = DateTime.Now.ToString();
            return person;
        }
    }
}
