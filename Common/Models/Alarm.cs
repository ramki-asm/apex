using System;


namespace Common.Models
{
    public class Alarm
    {
        public int Serial { get; set; }
        public string Module { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
    }
}
