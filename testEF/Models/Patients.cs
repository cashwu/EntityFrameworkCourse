using System;
using System.Collections.Generic;

namespace testEF.Models
{
    public partial class Patients
    {
        public Patients()
        {
            MapDoctorsPaients = new HashSet<MapDoctorsPaients>();
        }

        public int PatientId { get; set; }
        public string Name { get; set; }

        public ICollection<MapDoctorsPaients> MapDoctorsPaients { get; set; }
    }
}
