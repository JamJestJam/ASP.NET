using ASP.net_Aplication.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Image.EFImageRep {
    public partial class EFImageRep : IImageRep {
        private readonly DbConnect db;
        private static readonly Int32 perPage = 10;

        public EFImageRep(DbConnect db) {
            this.db = db;
        }
    }
}
