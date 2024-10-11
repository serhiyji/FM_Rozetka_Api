using FM_Rozetka_Api.Core.Interfaces;
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
        private readonly IDiscountService _discountService;

        public UpdateDiscountJob(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await UpdateDiscountsAsync();
        }

        private async Task UpdateDiscountsAsync()
        {
            Console.WriteLine("Discount Update...");

            var activateResult = await _discountService.ActivateScheduledDiscountsAsync();
            if (activateResult.Success)
            {
                Console.WriteLine("Successfully activated scheduled discounts.");
            }
            else
            {
                Console.WriteLine("Error activating scheduled discounts: " + activateResult.Message);
            }

            var deleteResult = await _discountService.DeleteExpiredDiscountsAsync();
            if (deleteResult.Success)
            {
                Console.WriteLine("Successfully removed overdue discounts.");
            }
            else
            {
                Console.WriteLine("Error removing expired discounts: " + deleteResult.Message);
            }
        }
    }
}
