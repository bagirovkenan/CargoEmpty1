using CargoEmpty.Context;
using CargoEmpty.Models.General.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Balance
{
    public class AddBalance
    {
        public static BalanceOperator ChangeBalance(UserDb user,decimal AddBalance, CargoDbContext db)
        {    
            
            user.Balance += (AddBalance);

            BalanceOperator Bo = new BalanceOperator() {Total = user.Balance , OutIn= AddBalance,UserDbId=user.Id,Date = DateTime.Now };
            return Bo;

        }

        public static decimal outPrice(decimal price)
        {
            if (price>0)
            {
                price = price * (-1);
                return price;
            }
            else
            {
                return price;
            }
        }

        public static int AddBonus(decimal price)
        {    
            var bonuc = price / 10;
            return Decimal.ToInt32(bonuc);
        }
    }
}