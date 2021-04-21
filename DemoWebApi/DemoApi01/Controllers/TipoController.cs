using DemoData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoController : ControllerBase
    {

        [HttpGet]
        public List<Tipo> Get()
        {
            myHelperData _contextData = new myHelperData();
            var contextresul =_contextData.GetTipo();
            return contextresul;

        }
    }
}
