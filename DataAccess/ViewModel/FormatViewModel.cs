using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
    public class FormatViewModel
    {
        public static string GetFormatVND(decimal amount)
        {
            string formattedAmount = amount.ToString("N2"); 
            return formattedAmount;
        }
    }
}
