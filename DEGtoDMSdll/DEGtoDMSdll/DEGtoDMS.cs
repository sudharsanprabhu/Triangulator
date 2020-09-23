using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEGtoDMSdll
{
    public class DEGtoDMS
    {
        public string deg2dms(string deg)
        {
            double data = double.Parse(deg);
            int degree = (int)data;
            double minutes_data = (data - degree) * 60;
            double minutes = (int)minutes_data;
            double seconds = (minutes_data - minutes) * 60;

            return (degree.ToString() + " " + minutes.ToString() + " " + seconds.ToString());
        }
    }
}
