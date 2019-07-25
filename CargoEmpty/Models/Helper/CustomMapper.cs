using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Helper
{
    public static class CustomMapper
    { 
        public static void ViewFromDb<ViewModel, DbModel>(this ViewModel vw, DbModel db)
        {
            var getTypVw = vw.GetType();
            var getTypeDb = db.GetType();

            var ProperiesVw = getTypVw.GetProperties();
            var ProperiesDb = getTypeDb.GetProperties();

            foreach (var i in ProperiesVw)
            {
                foreach (var l in ProperiesDb)
                {
                    if (i.Name.ToString() == l.Name.ToString())
                    {

                        l.SetValue(db, i.GetValue(vw));
                    }
                }

            }

          

        }
        //////////////////////////////////////////////////////////////////////////////
        ///
        public static DbModel ViewFromDb<ViewModel, DbModel>(this ViewModel vw, DbModel db, string PropName)
        {
            var getTypVw = vw.GetType();
            var getTypeDb = db.GetType();

            var ProperiesVw = getTypVw.GetProperties();
            var ProperiesDb = getTypeDb.GetProperties();

            foreach (var i in ProperiesVw)
            {
                foreach (var l in ProperiesDb)
                {
                    if (i.Name.ToString() == l.Name.ToString())
                    {
                        if (i.Name.ToString() != PropName)
                        {
                            l.SetValue(db, i.GetValue(vw));
                        }

                    }
                }

            }

            return db;

        }
        //////////////////////////////////////////////////////////////////////////////
        ///
        public static DbModel ViewFromDb<ViewModel, DbModel>(this ViewModel vw, DbModel db, string[] PropName)
        {
            var getTypVw = vw.GetType();
            var getTypeDb = db.GetType();
     
            var ProperiesVw = getTypVw.GetProperties();
            var ProperiesDb = getTypeDb.GetProperties();

            foreach (var i in ProperiesVw)
            {
                foreach (var l in ProperiesDb)
                {
                    if (i.Name.ToString() == l.Name.ToString())
                    {
                        foreach (var w in PropName)
                        {


                            if (i.Name.ToString() != w)
                            {
                                l.SetValue(db, i.GetValue(vw));
                            }
                        }
                    }
                }

            }

            return db;

        }

    }
}
