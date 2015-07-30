using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionInterception
{
    public interface IPrescription
    {
        int ID { get; set; }
        int PatientID { get; set; }
        string MedicationName { get; set; }
        string Dosage { get; set; }
    }
}
