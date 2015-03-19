//ograniczenie nadmiarowych using'ów

namespace MasterCoder.PKW.Mandates
{
    internal sealed class Mandate
    {
        public string PartShortName { get; set; }
        public string PartName { get; set; }
        public int Mandates { get; set; }

        public Mandate(string name1, string name2, int mandates)
        {
            PartName = name1;
            PartShortName = name2;
            Mandates = mandates;
        }
    }
}
