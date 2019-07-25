using CargoEmpty.Models.Main;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Models.Helper
{
    public static class ProsesImageFile
    {
        public static string ImagePath(string imgName, string ImageFilePath)
        {


            var ImgPath = Path.Combine(HttpContext.Current.Server.MapPath(ImageFilePath), imgName);
       
            return  ImgPath;
        }
        ///
        /// //////////////////////////////////////////////////////////////////////
        /// 
        public static string FileName(HttpPostedFileBase Image)
        {
            
            
                var a = Image.FileName;

                string imgExt = Path.GetExtension(Image.FileName);
                string imgName = Path.GetFileNameWithoutExtension(Image.FileName) + "_"
                    + DateTime.Now.ToString("yyyyMMddHHmmssfff") + imgExt;

                return imgName;
            
            
        }
        ///
        //////////////////////////////////////////////////////////////////////////
        ///
        /// 
        public static void SaveImageFile<T>(this T model, HttpPostedFileBase Image,string ImagePathFile) where T:PagesMainModel
        {
            var ImgNewName = FileName(Image);
            var ImgSavedPath = ImagePath(ImgNewName, ImagePathFile);
            Image.SaveAs(ImgSavedPath);
            model.ImagePath = ImagePathFile + "/" + ImgNewName;

        }

        ///
        //////////////////////////////////////////////////////////////////////////
        ///
        /// 
        public static string SaveImageFileGeneral<T>(this T model, HttpPostedFileBase Image, string ImagePathFile)
        {
            var ImgNewName = FileName(Image);
            var ImgSavedPath = ImagePath(ImgNewName, ImagePathFile);
            Image.SaveAs(ImgSavedPath);

            var savePath = ImagePathFile + "/" + ImgNewName;
            return savePath;
        }

        ///
        //////////////////////////////////////////////////////////////////////////
        ///
        /// 
        ///
        //////////////////////////////////////////////////////////////////////////
        ///
        /// 
        public static void DeleteImageFile(string ImgFullPath)
        {
            if (File.Exists(ImgFullPath))
            {
                File.Delete(ImgFullPath);
            }
        }
    }


}