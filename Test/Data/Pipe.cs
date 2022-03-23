namespace Test.Data
{
    public class Pipe
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Quality { get; set; }
        public string SteelGrade { get; set; }
        public double Weight { get; set; }
        public double Dy { get; set; }
        public double Dh { get; set; }
        public double S { get; set; }
        public int? PackageId { get; set; } = null;
        public virtual Package Package { get; set; }
    }
}
