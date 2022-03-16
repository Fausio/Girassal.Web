using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Models
{
    public class common
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int CreatedUserID { get; set; }
        public int? UpdatedUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int State { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

    }
}
