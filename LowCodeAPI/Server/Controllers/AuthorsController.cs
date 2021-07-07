using LowCodeAPI.Server.Data;
using LowCodeAPI.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCodeAPI.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorsController : EFControllerBase<Authors, pubsContext>
    {
        EFRepository<Authors, pubsContext> repository;

        public AuthorsController(EFRepository<Authors, pubsContext> _repository) 
            : base(_repository)
        {
            repository = _repository;
        }
        
    }
}
