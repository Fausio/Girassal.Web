using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Services.helpers
{
    public static class Querys
    {
        public static string updateInvoiceQuantity = @"UPDATE
                            Invoice
                        SET
                            Invoice.Quantity = Table_B.Quantity 
    
                        FROM
                            Invoice AS Table_A
                            INNER JOIN (SELECT i.Code, sum(c.Quantity) Quantity 
				                        FROM   Invoice i
				                        join   Clothing c on c.InvoiceId  = i.Id
				                        GROUP BY  i.Code) AS Table_B
                                ON Table_A.Code = Table_B.Code";
    }
}
