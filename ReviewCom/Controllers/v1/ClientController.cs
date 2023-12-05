using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ReviewCom.Controllers;
using ReviewCom.Services;
using ReviewComDAL.Models;
using ReviewComDAL.Repository;

namespace ReviewCom.Controllers.v1
{
    [Route("api/v1/client")]
    [ApiController]
    public class ClientController : AbstractController<Client, ClientRepository>
    {
        public ClientController(ClientRepository repository, ILoggingService loggingService) : base (repository, loggingService) {
        }
    }
}