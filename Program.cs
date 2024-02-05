using SagaExample.Entities;
using SagaExample.Interface;
using SagaExample.Operations;
using SagaExample.SagaManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagaExample
{
    public class Program
    {
        public static async Task Main()
        {
            var sagaSteps = new List<ISagaOrderSteps>
        {
            new PaymentStep(),
            new StockStep(),
            new DeliveryStep()
        };

            var saga = new SagaManager.SagaManager(sagaSteps);
            var order = new Order();

            try
            {
                await saga.SagaProcess(order);
                Console.WriteLine("Sipariş tamamlandı.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sipariş işlemi başarısız oldu: " + ex.Message);
            }
        }
    }
}
