using API2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API2.Controllers
{
    public class FeedBackController : ApiController
    {
        // GET: api/FeedBack
        public IEnumerable<IFeedBack> Get()
        {
            IFeedBack feedbacks = new IFeedBack();
            var temp = feedbacks.consutlarFeedBack();
            return temp;
        }

        // GET: api/FeedBack/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FeedBack
        public void Post([FromBody]IFeedBack value)
        {
            IFeedBack feedback = new IFeedBack();
            feedback.guardarFeedBack(value);
        }

        // PUT: api/FeedBack/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FeedBack/5
        public void Delete(int id)
        {
        }
    }
}
