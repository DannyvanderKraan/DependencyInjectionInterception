using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionInterception
{
    public class Prescription : IPrescription
    {
        public string Dosage { get; set; }

        public int ID { get; set; }

        public string MedicationName { get; set; }

        public int PatientID { get; set; }

        public override string ToString()
        {
            return string.Format("Prescription {0}, {1}, {2}, {3}.",
                ID,
                MedicationName,
                Dosage,
                PatientID);
        }
    }
}
