using SagaExample.Entities;
using SagaExample.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagaExample.Operations
{
    public class OrderOperations
    {
        //Burada 3 adet metot için de 3 adet service tanımlanabilirdi
        //Fakat ben bunları bölmektense tek bir dosya içerisinde yazdım. (Biraz da üşengeçlikten.)
        //Dilerseniz ayrı ayrı tanımlama yapabilirsiniz.

    }

    public class DeliveryStep : ISagaOrderSteps
    {
        public Task Process(Order order)
        {
            //Delivery işlemi ile ilgili bussines kuralları.
            return Task.CompletedTask;
        }

        public Task Rollback(Order order)
        {
            //Rollback metodu işlemleri
            return Task.Run(() => { Console.WriteLine("Task Rollback"); });
        }
    }

    public class PaymentStep : ISagaOrderSteps
    {
        public Task Process(Order order)
        {
            //Payment işlemi ile ilgili bussiness kuralları
            return Task.CompletedTask;
        }
        public Task Rollback(Order order)
        {
            //Rollback metodu işlemleri
            return Task.Run(() => { Console.WriteLine("Task Rollback"); });
        }
    }

    public class StockStep : ISagaOrderSteps
    {
        public Task Rollback(Order order)
        {
            //Rollback metodu işlemleri
            return Task.Run(() => { Console.WriteLine("Task Rollback"); });
        }

        public Task Process(Order order)
        {
            //Payment işlemi ile iligli bussines kuralları
            return Task.CompletedTask;
        }
    }
}
