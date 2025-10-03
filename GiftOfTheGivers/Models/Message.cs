namespace GiftOfTheGivers.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; }
    }
}
