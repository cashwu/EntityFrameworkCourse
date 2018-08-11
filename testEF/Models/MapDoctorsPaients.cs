using System;
using System.Collections.Generic;

namespace testEF.Models
{
    public partial class MapDoctorsPaients
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public Doctors Doctor { get; set; }
        public Patients Patient { get; set; }
    }
}
