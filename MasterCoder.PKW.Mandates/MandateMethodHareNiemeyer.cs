using System;
using System.Collections.Generic;
using System.Linq;
//ograniczenie nadmiarowych using'ów

namespace MasterCoder.PKW.Mandates
{
    public class MandateMethodHareNiemeyer : MandateMethod
    {
        public override List<Mandate> CalculateMandates(List<Vote> votes, int mandatesCount)
        {
            var v = votes;
            List<Mandate> partMandates = InitializeMandates(v);

            List<double> tab = new List<double>();
            var totalVotes = v.Sum(x => x.ValidVotes);

            int mandCounter=0;
            for(int i=0; i<v.Count;i++)
            {
                // poprawka błędu typu "loss of fraction"
                // jeżeli dzielimy same liczby typu int - część ułamkowa jest pomijana
                // trzeba któryś z elementów działanai jawnie skastować na double
                tab.Add(((double)v[i].ValidVotes * mandatesCount) / totalVotes);
                partMandates[i].Mandates = (int)Math.Floor(tab[i]);
                tab[i] -= partMandates[i].Mandates;
                mandCounter += partMandates[i].Mandates;
            }

            double max;
            int maxInd=0;

            while(mandCounter<mandatesCount)
            {
                max = -1;
                for(int i=0; i<v.Count; i++)
                {
                    if(max<tab[i])
                    {
                        max = tab[i];
                        maxInd = i;
                    }
                }

                partMandates[maxInd].Mandates++;
                mandCounter++;
                tab[maxInd] = 0;
            }

            return partMandates;
        }

       
    }
}
