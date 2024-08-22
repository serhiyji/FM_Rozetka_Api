using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.Services.Quarz
{
    public class UpdateDiscountJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await UpdateDiscountsAsync();
        }

        private Task UpdateDiscountsAsync()
        {
            Console.WriteLine("Оновлення знижок...");

            return Task.CompletedTask;
        }
    }
}
