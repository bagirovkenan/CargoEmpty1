using CargoEmpty.Models.General.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Balance
{
    public class BalanceOperator
    {
        public int Id { get; set; }
        public decimal? OutIn { get; set; }
        public decimal? Total { get; set; }
        public DateTime? Date { get; set; }

        public int UserDbId { get; set; }
        public virtual UserDb User { get; set; }
    }
}