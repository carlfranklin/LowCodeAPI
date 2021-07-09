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
    public class AuthorsController : EFControllerBase<Author, pubsContext>
    {
        EFRepository<Author, pubsContext> repository;

        public AuthorsController(EFRepository<Author, pubsContext> _repository) 
            : base(_repository)
        {
            repository = _repository;
        }
        
    }
}
