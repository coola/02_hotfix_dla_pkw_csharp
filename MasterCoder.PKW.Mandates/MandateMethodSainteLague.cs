using System.Collections.Generic;
using System.Linq;
//ograniczenie nadmiarowych using'ów

namespace MasterCoder.PKW.Mandates
{
    internal class MandateMethodSainteLague : MandateMethod
    {
        public override List<Mandate> CalculateMandates(List<Vote> votes, int mandatesCount)
        {
            List<Mandate> partMandates = InitializeMandates(votes);

            List<float> calcTab = new List<float>(votes.Select(x => (float)x.ValidVotes));

            int maxInd = 0;

            //poprawnienie błędu w warunku wyjścia z pętli było:i >= 0, powinno być i > 0 
            for (int i = mandatesCount; i > 0; i--)
            {
                float m = -1;
                for (int j = 0; j < calcTab.Count; j++)
                {
                    if (m < calcTab[j])
                    {
                        m = calcTab[j];
                        maxInd = j;
                    }
                }

                partMandates[maxInd].Mandates++;
                calcTab[maxInd] = Calc(votes[maxInd].ValidVotes, partMandates[maxInd].Mandates);
            }

            return partMandates;
        }

        private float Calc(int v, int mandates)
        {
            //poprawka współczynnika - usunięcie mnożenia przez jeden, dodanie mnożenia przez dwa zmiennej mandates
            return (float) (v / (2 * mandates + 1.0));
        }
    }
}
