using LowCodeAPI.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LowCodeAPI.Client.Services
{
    public class AuthorsManager : APIRepository<Authors>
    {
        HttpClient http;

        public AuthorsManager(HttpClient _http)
            : base(_http, "authors", "AuId")
        {
            http = _http;
        }
    }
}
