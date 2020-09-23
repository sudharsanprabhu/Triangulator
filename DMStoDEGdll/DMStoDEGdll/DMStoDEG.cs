using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMStoDEGdll
{
    public class DMStoDEG
    {
        
        public double dms2deg(string dms)
        {
           string[] dms_parts = dms.Split(' ');
           double deg=0;
            if(dms_parts.Length==3)
            {
                
                
                    double degrees = double.Parse(dms_parts[0]);
                    double minutes = double.Parse(dms_parts[1]) / 60;
                    double seconds = double.Parse(dms_parts[2]) / 3600;
                    if (degrees >= 0)
                        deg = degrees + minutes + seconds;
                    else
                        deg = degrees - minutes - seconds;
                
                

            }
            return deg;
        }

    }
}
