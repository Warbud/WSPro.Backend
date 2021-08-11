namespace WSPro.Backend.Model
{
    public class DelayCause
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public DelayCause Parent { get; set; }
    }
}