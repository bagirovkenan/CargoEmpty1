﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Pages.Carusel
{
    public class CaruselView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public HttpPostedFileBase File { get; set; }
        public bool IsActive { get; set; }



    }
}