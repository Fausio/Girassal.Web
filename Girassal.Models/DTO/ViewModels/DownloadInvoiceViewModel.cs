using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Models.DTO.ViewModels
{
    public class DownloadInvoiceViewModel : CommunVIewModel
    {
       

        [Display(Name = "Em processamento")]
        public bool Processing { get; set; }

        [Display(Name = "Já Finalizadas")]
        public bool Finalized { get; set; }


        [Display(Name = "Data Inicial")]
        public DateTime StartdDate { get; set; }

        [Display(Name = "Data 'Final")]
        public DateTime EndDate { get; set; }

        public DownloadInvoiceViewModel()
        {
            var now = DateTime.Now.Date;
            StartdDate = now.AddMonths(-1);
            EndDate = now ;
            Finalized = true;
        }
    }
}
