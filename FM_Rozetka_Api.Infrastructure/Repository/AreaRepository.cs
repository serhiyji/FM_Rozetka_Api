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
    internal class AreaRepository : Repository<Area>, IAreaRepository
    {
        public AreaRepository(DbContextOptions<AppDBContext> dbContextOptions)
            : base(dbContextOptions) { }
    }
}
