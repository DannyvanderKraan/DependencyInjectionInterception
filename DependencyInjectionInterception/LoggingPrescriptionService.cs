using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionInterception
{
    public class LoggingPrescriptionService: IPrescriptionService
    {
        IPrescriptionService Service { get; set; }
        private int UserID { get; set; }

        public LoggingPrescriptionService(IPrescriptionService service, int userID)
        {
            if(service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }
            if(userID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userID));
            }
            this.Service = service;
            this.UserID = userID;
        }

        public IPrescription GetPrescriptionByID(int ID)
        {
            IPrescription prescription = Service.GetPrescriptionByID(ID);
            //TODO write to log that user ? read prescription ? of patient ? at DateTime.Now
            Console.WriteLine("User {0} read prescription {1} of patient {2}", this.UserID, ID, prescription.PatientID);
            return prescription;
        }
    }
}
