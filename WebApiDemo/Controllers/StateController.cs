using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class StateController : ApiController
    {
        StateRepository stateRepository = new StateRepository();

        // GET: api/State
        public IEnumerable<States> Get()
        {
            return stateRepository.GetStates();
        }

        //// GET: api/State/5
        public States Get(int id)
        {
            return stateRepository.GetStateById(id);
        }

        // POST: api/State
        public void Post([FromBody]States state)
        {
            stateRepository.InsertState(state);
        }

        // PUT: api/State/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/State/5
        public void Delete(int id)
        {
        }
    }
}
