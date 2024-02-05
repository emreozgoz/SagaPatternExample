using SagaExample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagaExample.Interface
{
    public interface ISagaOrderSteps
    {
        //Tek bir dosya içerisinde tanımlama yapıldı aynı Operations içerisinde olduğu gibi.
        // Ufak olan bir kodu çok fazla bölmenin bir anlamı yok.
        //Her biri entityi alan servislerimiz
        Task Process(Order order);
        Task Rollback(Order order);
    }
}
