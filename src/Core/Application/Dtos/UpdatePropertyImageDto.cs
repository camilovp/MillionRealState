using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Dtos
{
    public class UpdatePropertyImageDto
    {
        public string IdPropertyImage { get; set; }
        public string IdProperty { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }
    }
}
