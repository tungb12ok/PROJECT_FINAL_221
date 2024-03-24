using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Repository
{
    public class ProductRepository
    {
        public List<Product> filter(int? cateId, string name, int? min, int? max) => ProductDAO.Instance.filter(cateId, name, min, max);
    }
}
