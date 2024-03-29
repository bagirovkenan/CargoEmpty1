﻿using CargoEmpty.Context;
using CargoEmpty.Models.General.Order;
using CargoEmpty.Models.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CargoEmpty.Models.General.Bundel
{
    public class GetIndexBundel
    {
        public int Id { get; set; }
        public int UserDbId { get; set; }
        public string CustumerName { get; set; }
        public int UserCode { get; set; }
        public decimal Price { get; set; }
        public decimal? DeliveryPrice { get; set; }
        public int? UnicalNumberReception { get; set; }
        public List<BundelLinks> Links { get;  } = new List<BundelLinks>();
        public string InvoicePath { get; set; }
        public string ShopName { get; set; }
        public int OrderStatusId { get; set; }
        public string CountryName { get; set; }
  

        [DisplayName("S.E")]
        public DateTime CreateDate { get; set; }
        [DisplayName("X.A")]
        public DateTime? ReceivingTime { get; set; }
        [DisplayName("Y.D")]
        public DateTime? OnWay { get; set; }
        [DisplayName("B.A")]
        public DateTime? InBaku { get; set; }
        [DisplayName("C.T")]
        public DateTime? DeliveryTime { get; set; }

        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }


        //????????
        public static GetIndexBundel Create(BundelsDb bundel)
        {
            GetIndexBundel gt = new GetIndexBundel();
            bundel.ViewFromDb(gt);
            Task task1 = Task.Run(() =>
            {
                using (CargoDbContext dbs = new CargoDbContext())
                {
                    gt.CountryName = dbs.Countries.AsParallel().FirstOrDefault(f => f.Id == bundel.CountryId).CauntryName;
                    var orders = dbs.Orders.AsParallel().Where(w => w.BundelsDbId == bundel.Id).ToList();
                    if (orders != null)
                    {
                        for (var i = 0; i < orders.Count; i++)
                        {
                            gt.Links.Add(new BundelLinks(orders[i]));
                        }
                    }
                }
            });

            Task task2 = Task.Run(() =>
           {
               using (CargoDbContext dbs = new CargoDbContext())
               {

                   gt.CountryName = dbs.Countries.AsParallel().FirstOrDefault(f => f.Id == bundel.CountryId).CauntryName;
                   var decs = dbs.Declerations.AsParallel().Where(w => w.BundelsDbId == bundel.Id).ToList();
                   if (decs != null)
                   {
                       for (var i = 0; i < decs.Count; i++)
                       {
                           gt.Links.Add(new BundelLinks(decs[i]));
                       }
                   }
               }
           });

            Task.WaitAll(task1, task2);

            return gt;
        }
    }
}