using CargoEmpty.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Pages.Calculate
{
    public static class SelectTarif
    {
        public static decimal SelectTa(int Id, decimal Weight)
        {
            decimal WeightPrice;
            using (CargoDbContext db = new CargoDbContext())
            {
                var tarif = db.Tarifs.Where(w => w.CountryId == Id);
                var CountryMaxWeight = tarif.Max(m => m.MaxWeight);
                if (Weight > CountryMaxWeight)
                {
                    var CountryMaxTarif = tarif.FirstOrDefault(f => f.MaxWeight == CountryMaxWeight);
                    WeightPrice = CountryMaxTarif.WeightPrice;
                }
                else
                {
                    WeightPrice = tarif.FirstOrDefault(f =>f.MaxWeight >= Weight).WeightPrice;
                }
            }
            return WeightPrice;
        }


        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static decimal CalculateVolume(FrontCalculateBundle bundle)
        {
            var weihgtPrice = SelectTarif.SelectTa(bundle.CountryId, bundle.BundleWeight);
            var total = ((bundle.BundleHeight * bundle.BundleLenght * bundle.BundleWidth * weihgtPrice) / 6000) * bundle.BundelCount;

            return total;
        }

        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static decimal CalculateWeight(FrontCalculateBundle bundle)
        {
            var total = ((SelectTarif.SelectTa(bundle.CountryId, bundle.BundleWeight)) * bundle.BundleWeight) * bundle.BundelCount;

            return total;
        }
    }
}