using SagaExample.Entities;
using SagaExample.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagaExample.SagaManager
{
    public  class SagaManager
    {
        private readonly List<ISagaOrderSteps> _steps;

        public SagaManager(List<ISagaOrderSteps> steps)
        {
            _steps = steps;
        }
        public async Task SagaProcess(Order order)
        {
            foreach (var step in _steps)
            {
                try
                {
                    await step.Process(order);
                }
                catch (Exception)
                {
                    // Hata durumunda geri alma işlemini tetikle
                    await CompensateOrder(order, _steps.IndexOf(step));
                    throw;
                }
            }
        }

        private async Task CompensateOrder(Order order, int startIndex)
        {
            for (int i = startIndex; i >= 0; i--)
            {
                await _steps[i].Rollback(order);
            }
        }
    }
}
