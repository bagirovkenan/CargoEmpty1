using CargoEmpty.Context;
using CargoEmpty.Models.General.User;
using CargoEmpty.Models.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CargoEmpty.Models.General.Decleration
{
    public class CreateDeclerationView
    {
        public int? Id { get; set; }
        public int BundleCount { get; set; }
        public string DecDate { get; set; }
        public string FromOrder { get; set; }
        public string ShopName { get; set; }
        public decimal OrderPrice { get; set; }
        public int TrackingCode { get; set; }
        public HttpPostedFileBase Invoice { get; set; }
        public string Comment { get; set; }
        public bool CreatAdmin { get; set; }

        public int? OrderDbId { get; set; }
        public int? UserDbId { get; set; }
        public int CategoryId { get; set; }
        public int CountryId { get; set; }




        public static DeclerationDb Creaet(int UserId, CreateDeclerationView create)
        {
            DeclerationDb dec = new DeclerationDb();
            create.ViewFromDb(dec);
            dec.OrderPrice = create.OrderPrice * create.BundleCount;
            dec.InvoicePath = dec.SaveImageFileGeneral(create.Invoice, "/Image/Decleration");
            dec.OrderDate = DateTime.Parse(create.DecDate);
            dec.UserDbId = UserId;
            if (create.OrderDbId != null)
            {
                using (CargoDbContext db = new CargoDbContext())
                {
                    var Order =  db.Orders.FirstOrDefault(f => f.Id == create.OrderDbId && f.UserDbId==UserId);
                    if (Order != null)
                    {
                        Order.Ordered = true;
                    }
                    else
                    {
                        Order.Ordered = false;
                    }
                }
            }

            return dec;
        }

    }
}