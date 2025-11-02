using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPD421.BLL.Services
{
    public class ServiceResponse
    {
        public required string? Message { get; set; }
        public bool IsSuccess { get; set; } = true;
        public object? Data { get; set; } = null;
        public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.OK;
    }
}
