using System.Collections.ObjectModel;

namespace Test.Data
{
    public class Package
    {
        public int PackageId { get; set; }
        public int Number { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<Pipe> Pipes
        { get; private set; } =
            new ObservableCollection<Pipe>();
    }
}
