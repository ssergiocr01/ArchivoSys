using ArchivoSys.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchivoSys.Web.Models
{
    public class DataContextLocal : DataContext
    {
        public System.Data.Entity.DbSet<ArchivoSys.Domain.DocumentType> DocumentTypes { get; set; }

        public System.Data.Entity.DbSet<ArchivoSys.Domain.Province> Provinces { get; set; }

        public System.Data.Entity.DbSet<ArchivoSys.Domain.Canton> Cantons { get; set; }

        public System.Data.Entity.DbSet<ArchivoSys.Domain.District> Districts { get; set; }
    }
}