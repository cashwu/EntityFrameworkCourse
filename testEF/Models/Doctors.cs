using System;
using System.Collections.Generic;

namespace testEF.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            MapDoctorsPaients = new HashSet<MapDoctorsPaients>();
        }

        public int DoctorId { get; set; }
        public string Name { get; set; }

        public ICollection<MapDoctorsPaients> MapDoctorsPaients { get; set; }
    }
}
