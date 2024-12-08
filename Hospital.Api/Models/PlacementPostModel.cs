namespace Hospital.Api.Models
{
    public class PlacementPostModel
    {
        public string WorkerId { get; set; }
        public string Day { get; set; }
        public bool Morning { get; set; }
        public bool Evening { get; set; }
        public bool Night { get; set; }
        //public WardPostModel Ward { get; set; }
        public int WardId { get; set; }
    }
}
