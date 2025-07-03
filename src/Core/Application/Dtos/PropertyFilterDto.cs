using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Dtos
{
    public class PropertyFilterDto
    {
        public string? IdOwner { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
