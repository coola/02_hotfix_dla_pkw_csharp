//ograniczenie nadmiarowych using'ów

namespace MasterCoder.PKW.Mandates
{
    public sealed class Mandate
    {
        public string PartShortName { get; set; }
        public string PartName { get; set; }
        public int Mandates { get; set; }

        //poprawienie błędu związanego z pomyleniem parametrów wywołania konstruktora
        internal Mandate(string partShortName, string partName, int mandates)
        {
            PartShortName = partShortName;
            PartName = partName;
            Mandates = mandates;
        }
    }
}
