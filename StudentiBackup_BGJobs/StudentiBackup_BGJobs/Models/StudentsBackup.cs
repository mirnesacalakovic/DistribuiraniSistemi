namespace StudentiBackup_BGJobs.Models
{
    public class StudentsBackup
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string ImePrezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Index { get; set; }
        public string Smer { get; set; }
    }
}
