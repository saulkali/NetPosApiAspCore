using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PyPosApi.modules.moduleClient.controller
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        

        [HttpDelete("delete/{idClient}")]
        public void DeleteClient(Guid idClient)
        {

        }

        [HttpGet("create")]
        public void CreateClient()
        {
            
        }
        
    }
}

