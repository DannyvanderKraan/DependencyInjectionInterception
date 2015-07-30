using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionInterception
{
    public interface IPrescriptionService
    {
        [Description("gets a specific prescription")]
        IPrescription GetPrescriptionByID(int ID);
    }
}
