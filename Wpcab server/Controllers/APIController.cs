
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WpcabServer.Model;
using WpcabServer.Utils;

namespace WpcabServer.Controllers
{
    
    [Route("api/")]
    public class APIController : Controller
    {
        private IConnector connector = Factory.GetConnector();
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("getUsersByPage/{page}")]
        public Task<Response> GerUsersByPage(int page)
        {
            var result = connector.GetUsersByPage(page);

            return result;

        }

        [HttpGet("getUserById/{id}")]
        public User GetUserById(string id)
        {
            var result = connector.GetUserById(id);

            return result;

        }

        // POST api/values
        [HttpPost("insertUser")]
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
