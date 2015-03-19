//ograniczenie nadmiarowych using'ów

namespace MasterCoder.PKW.Mandates
{
    internal sealed class Vote
    {
        public string PartShortName { get; set; }
        public string PartName { get; set; }
        public int ValidVotes { get; set; }

        public Vote(string partShortName, string partName, int validVotes)
        {   
            PartShortName = partShortName.ToUpper();
            PartName = partName;
            ValidVotes = validVotes;
        }
    }
}
