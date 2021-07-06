using System;
using System.Collections.Generic;
using EverestEngineeringUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace EverestEngineering
{
    class Program
    {
        static ServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();
            Utilities.serviceProvider = _serviceProvider;
            DisplayMenu.Display();
        }

        //Global error handler for unhndled exception
        static void UnhandledExceptionTrapper(Object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Unhandled error occured stopping the application");
            Environment.Exit(0);
        }

        //Registering service for dependency injection. 
        private static void RegisterServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IOfferCode, OfferCodeProcessing>();
            services.AddSingleton<IDeliveryCostEstimation, DeliveryCost>();
            services.AddSingleton<IDeliveryTimeEstimation, DeliveryTimeEstimation>();
            
            _serviceProvider = services.BuildServiceProvider();
        }

    }
}
