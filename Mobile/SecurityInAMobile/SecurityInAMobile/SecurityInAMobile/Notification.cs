using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityInAMobile
{
    public class Notification
    {
        public string Name { get; set; }
        public string Data { get; set; }
        public bool Seen { get; set; }
        public DateTime Date
        {
            get
            {
                return DateTime.Now;
            }
            set {; }
        }

        public string DataString
        {
            get
            {
                return Date.ToString() + " -- " + Name;
            }
            set {; }
        }

        public string Color
        {
            get
            {
                if (Seen)
                {
                    return "Gray";
                }
                else
                {
                    return "Blue";
                }
            }
            set {; }
        }
    }
}
