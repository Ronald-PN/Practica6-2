﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoCRUD_WEB.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public Decimal Precio { get; set; }
    }
}