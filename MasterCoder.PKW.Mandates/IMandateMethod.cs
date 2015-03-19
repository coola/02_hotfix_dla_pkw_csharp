using System.Collections.Generic;
//ograniczenie nadmiarowych using'ów

namespace MasterCoder.PKW.Mandates
{   
    interface IMandateMethod
    {
        List<Mandate> CalculateMandates(List<Vote> votes, int mandates);
    }
}
