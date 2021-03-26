using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPSTracker.Models
{
    public class Route
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        [OneToMany]
        public List<Waypoint> Waypoints { get; set; }
    }
}