namespace Hospital
{
    public class Placement
    {
        public int Id { get; set; }
        public string WorkerId { get; set; }
        public string Day { get; set; }
        public bool Morning { get; set; }
        public bool Evening { get; set; }
        public bool Night { get; set; }
        public int WardId { get; set; }
    }
}
