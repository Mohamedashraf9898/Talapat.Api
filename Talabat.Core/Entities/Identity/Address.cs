using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities.Identity
{
    public class Address : BaseEntity
    {
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public string  Street { get; set; } = null!;
        public string  City { get; set; } = null!;
        public string  Country { get; set; } = null!;
        public string ApplicationUserId { get; set; }=null!;
        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
