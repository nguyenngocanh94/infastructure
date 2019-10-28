﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geardao.Deploy.Supervisor.Ef;
using Microsoft.AspNetCore.Mvc;

namespace Geardao.Deploy.Supervisor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly SupervisorContext _dbContext;

        public ValuesController(SupervisorContext dbContext):base()
        {
            _dbContext = dbContext;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _dbContext.Worker.Add(new Ef.Model.Worker()
            {
                Id = 1,
                Ip="102.112.334.11"
            }) ;
            _dbContext.SaveChanges();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
