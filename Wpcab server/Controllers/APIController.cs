using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WpcabServer.Model;
using WpcabServer.Link;

namespace WpcabServer.Controllers
{
    
    [Route("api/")]
    public class APIController : Controller
    {
        private IConnector connector = Connector.getInstance();
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("getUser/{page}")]
        public Task<Response> GetAllUser(int page)
        {
            var result = connector.FetchUser(page);

            return result;

        }

        // POST api/values
        [HttpPost("InsertUser")]
        public bool InserUser([FromBody]User user)
        {
            var result =connector.InsertUser(user);

            return result;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
