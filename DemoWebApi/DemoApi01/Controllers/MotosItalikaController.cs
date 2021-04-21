using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoData;

namespace DemoApi01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotosItalikaController : ControllerBase
    {
        

        [HttpGet]
        public List<MotosItalika> Get()
        {
            myHelperData _contextData = new myHelperData();
            return _contextData.GetMotos();
            
        }


        [HttpPost]

        public void Post([FromBody] MotosItalika value)
        {
            myHelperData _contextData = new myHelperData();
            _contextData.SaveMotos(value);
        
        
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            myHelperData _contextData = new myHelperData();
            
            _contextData.DELETEMotos(id);


        }
    }
}
