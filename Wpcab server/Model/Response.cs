using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WpcabServer.Model
{
    public class Response
    {
        public Response(IEnumerable<User> users, string nextId, long total)
        {
            Users = users;
            NextId = nextId;
            Total = total;
        }

        public IEnumerable<User> Users { get; set; }
        public string NextId { get; set; }
        public long Total { get; set; }
    }
}
