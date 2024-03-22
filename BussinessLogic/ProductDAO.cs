using BussinessLogic.Repository;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class ProductDAO
    {
        private QuickMarketContext context = new QuickMarketContext();
        private static ProductDAO instance = null;
        private readonly static Object instanceLock = new Object();
        public ProductDAO()
        {
        }

        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Product> filter(int? cateId, string name, int? min, int? max)
        {
            List<Product> products = new List<Product>();

            if (cateId != null)
            {
                products = context.Products
                    .Include(x => x.User)
                    .Include(x => x.Category)
                    .Include(x => x.Status)
                    .Where(x => x.CategoryId == cateId).ToList();

            }
            if (name != null)
            {
                products = context.Products.Where(x => x.Name.Contains(name)).ToList();

            }
            if (min != null && max != null)
            {
                products = context.Products.Where(x => x.Price >= min && x.Price <= max).ToList();

            }
            if (min != null && max == null)
            {
                products = context.Products.Where(x => x.Price >= min).ToList();

            }
            if (max != null && min == null)
            {
                products = context.Products.Where(x => x.Price <= max).ToList();

            }
            products = products.Where(x => x.StatusId == 1).ToList();
            return products;
        }
    }
}
