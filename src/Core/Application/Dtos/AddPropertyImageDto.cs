using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Dtos
{
    public class AddPropertyImageDto
    {
        public string IdProperty { get; set; }
        public IFormFile AttachedFile { get; set; }
        public bool Enabled { get; set; }
    }
}
