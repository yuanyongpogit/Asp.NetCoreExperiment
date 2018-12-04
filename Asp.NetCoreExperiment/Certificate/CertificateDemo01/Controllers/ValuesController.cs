﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CertificateDemo01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            var cer = HttpContext.Connection.ClientCertificate;
            var cer1 = HttpContext.Connection.GetClientCertificateAsync().Result;
            if (cer == null)
            {
                return BadRequest();
            }
            else
            {
                var ver = cer.Verify();
                if (ver == false)
                {
                    return BadRequest();
                }
                else
                {
                    return new string[] { "value1", "value2" };
                }
            }
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
