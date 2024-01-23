using System;
namespace Dapper.Models
{
    public class Message
    {
        public Display Display { get; set; }
        public string Code { get; set; }
        public string Detail { get; set; }
    }

    public class Display
    {
        public string TH { get; set; }
        public string EN { get; set; }
    }
}

