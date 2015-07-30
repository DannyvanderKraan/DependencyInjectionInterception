using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionInterception
{
    class Program
    {
        public static IUnityContainer Container { get; set; }

        static void Main(string[] args)
        {
            Container = new UnityContainer();
            Container.AddNewExtension<Interception>();

            Container.RegisterType<IPrescription, Prescription>();
            Container.RegisterType<IPrescriptionService, PrescriptionService>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<LoggingInterceptionBehavior>());

            IPrescriptionService service = Container.Resolve<IPrescriptionService>();

            IPrescription prescription = service.GetPrescriptionByID(1);

            Console.WriteLine("Retrieved: {0}", prescription);

            Console.ReadKey();
        }
    }
}
