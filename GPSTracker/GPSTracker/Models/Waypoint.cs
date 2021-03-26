using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPSTracker.Models
{
    public class Waypoint
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey]
        public int RouteID { get; set; }

        public float Latitude { get; set; }

        public float Longtitude { get; set; }

        public DateTime Date { get; set; }
    }
}