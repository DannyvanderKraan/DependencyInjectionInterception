using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System.ComponentModel;

namespace DependencyInjectionInterception
{
    public class PrescriptionService : IPrescriptionService
    {
        public IPrescription GetPrescriptionByID(int ID)
        {
            Console.WriteLine("{0} is called!", nameof(GetPrescriptionByID));
            IPrescription prescription = Program.Container.Resolve<IPrescription>();
            prescription.ID = ID;

            switch (ID)
            {
                case 1:
                    prescription.PatientID = 1;
                    prescription.MedicationName = "Aspirin";
                    prescription.Dosage = "2 tablets each day";
                    break;
                case 2:
                    prescription.PatientID = 1;
                    prescription.MedicationName = "Unisom";
                    prescription.Dosage = "1 tablet each day";
                    break;
                case 3:
                    prescription.PatientID = 2;
                    prescription.MedicationName = "Dulcolax";
                    prescription.Dosage = "2 tablets every other day";
                    break;
                case 4:
                    prescription.PatientID = 3;
                    prescription.MedicationName = "Travatan";
                    prescription.Dosage = "3 drops each day";
                    break;
                case 5:
                    prescription.PatientID = 4;
                    prescription.MedicationName = "Canesten";
                    prescription.Dosage = "Apply 6 times each day";
                    break;
                default:
                    throw new ArgumentException(String.Format("{0} has unknown value", nameof(ID)));
            }

            return prescription;
        }
    }
}
