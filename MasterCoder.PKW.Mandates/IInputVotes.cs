using System.Collections.Generic;
//ograniczenie nadmiarowych using'ów

namespace MasterCoder.PKW.Mandates
{
    public interface IInputVotes
    {
        List<Vote> GetAllValidVotes();
        List<Vote> GetAllValidVotesForPart(string partShortName);
    }
}
