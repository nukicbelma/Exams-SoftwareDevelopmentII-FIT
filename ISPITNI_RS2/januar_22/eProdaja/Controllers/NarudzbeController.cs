using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.Database;
using eProdaja.Model.Requests;
using eProdaja.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class NarudzbeController : ControllerBase
    {
        private readonly INarudzbeService _service;

        public NarudzbeController(INarudzbeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IList<Model.Narudzbe> GetAll([FromQuery] NarudzbeSearchRequest request)
        {
            return _service.GetAll(request);
        }
    }
}
