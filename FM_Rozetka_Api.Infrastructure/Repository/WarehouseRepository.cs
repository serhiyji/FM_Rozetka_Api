using FM_Rozetka_Api.Core.Entities.NovaPost;
using FM_Rozetka_Api.Core.Interfaces;
using FM_Rozetka_Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Infrastructure.Repository
{
    internal class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(DbContextOptions<AppDBContext> dbContextOptions)
            : base(dbContextOptions) { }
    }
}
