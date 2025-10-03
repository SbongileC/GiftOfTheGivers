﻿namespace GiftOfTheGivers.Models
{
    public class Volunteer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Skills { get; set; }
        public string Availability { get; set; }
        public string Location { get; set; }
        public string ? TaskPreference { get; set; }
        public bool IsAssigned { get; set; }
        public string? TaskAssigned { get; set; }
    }
}
