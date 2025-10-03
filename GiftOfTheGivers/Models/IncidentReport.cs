namespace GiftOfTheGivers.Models
{
    public class IncidentReport
    {
        public int Id { get; set; }
        public string IncidentType { get; set; } // e.g. flood, fire, earthquake
        public string Location { get; set; } // e.g. city, town, village
        public string Description { get; set; } // brief description of the incident
        public DateTime IncidentDate { get; set; } // date of the incident
        public string ReporterName { get; set; } // name of the person reporting
        public string ReporterContact { get; set; } // contact info of the reporter
        public string Status { get; set; } // e.g. reported, in progress, resolved
    }
}
