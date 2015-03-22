using System.Collections.Generic;
using System.Linq;
//ograniczenie nadmiarowych using'ów

namespace MasterCoder.PKW.Mandates
{
    public class MandateMethodDHondta : MandateMethod
    {
        public override List<Mandate> CalculateMandates(List<Vote> votes, int mandatesCount)
        {
            var v = votes;
            List<Mandate> partMandates = InitializeMandates(v);

            List<double> tab = new List<double>(v.Select(x => (double)x.ValidVotes));

            int maxInd = 0;

            for (int i = mandatesCount; i > 0; i--)
            {
                double max = -1;
                for (int j = 0; j < tab.Count; j++)
                {
                    if (max < tab[j])
                    {
                        max = tab[j];
                        maxInd = j;
                    }
                }

                partMandates[maxInd].Mandates++;
                tab[maxInd] = Calc(v[maxInd].ValidVotes, partMandates[maxInd].Mandates);
            }

            return partMandates;
        }

        private double Calc(int v, int mandates)
        {
            // rzutowanie v na double jest nadmiarowe
            // po co mnożyć przez 1.0?
            // usunięcie mnożenia przez dwa - mnożenie przez dwa współczynnika powoduje błąd obliczeń
            return (v / (mandates + 1.0));
        }
    }
}
