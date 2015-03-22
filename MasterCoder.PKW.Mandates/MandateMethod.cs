
using System.Collections.Generic;


namespace MasterCoder.PKW.Mandates
{
    // wyniesienie wspólnego kodu dla algorytmów obliczeń do klasy abstrakcyjnej
    internal abstract class MandateMethod : IMandateMethod
    {
        protected List<Mandate> InitializeMandates(List<Vote> v)
        {
            List<Mandate> partMandates = new List<Mandate>(v.Count);

            foreach (var vote in v)
            {
                var mandate = new Mandate(vote.PartShortName, vote.PartName, 0);
                partMandates.Add(mandate);
            }

            return partMandates;
        }

        public abstract List<Mandate> CalculateMandates(List<Vote> votes, int mandates);
    }
}
