using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Models.DTO.ViewModels
{
   public abstract class CommunVIewModel 
    {
        public int MessageStatus { get; set; }
        public string MessageText { get; set; }
    }
}
