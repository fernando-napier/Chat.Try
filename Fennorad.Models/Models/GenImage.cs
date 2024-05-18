using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fennorad.Models.Models
{
    public class GenImage
    {
        public string AltText { get; set; }
        public string ImageUrl { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
        public TimeSpan ExpiresIn { get; set; }
    }
}
