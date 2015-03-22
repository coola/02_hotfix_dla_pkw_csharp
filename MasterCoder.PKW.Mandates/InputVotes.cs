using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//ograniczenie nadmiarowych using'ów

namespace MasterCoder.PKW.Mandates
{

    // interfejs IInputVote nie był nigdzie używany, 
    // więc zostało zamienione wywołanie implementacji na wywołanie tego interfejsu
    internal class InputVotes : IInputVotes
    {
        private List<Vote> v { get; set; }
        private string FilePath { get; set; }

        public InputVotes(string votesFilesPath)
        {
            v = new List<Vote>();
            FilePath = votesFilesPath;
            Initialize();
        }

        private void Initialize()
        {
            string[] f = Directory.GetFiles(FilePath);

            for (int i = 0; i < f.Length; i++)
            {
                if (FileNameValidation.Validate(Path.GetFileName(f[i])))
                {
                    string[] l = File.ReadAllLines(f[i]);
                    InitializeValidVotesFromFileData(l);
                }
            }
        }

        private void InitializeValidVotesFromFileData(string[] l)
        {
            for(int i=0; i<l.Length;i++)
            {
                
                var f = l[i].Split(';');
                //dodanie walidacji dla danych wejściowych z pliku. Zgodnie ze specyfikacją, złe dane nie są ładowane.
                var tempParse = 0;
                var valid = f.Length == 3 && Int32.TryParse(f[2], out tempParse);
                if (valid)
                {
                    var vote = new Vote(f[0], f[1], tempParse);

                    bool updated = false;

                    for (int j = 0; j < v.Count(); j++)
                    {
                        if (v[j].PartShortName == vote.PartShortName)
                        {
                            v[j].ValidVotes = vote.ValidVotes;
                            updated = true;
                            break;
                        }
                    }

                    if (!updated)
                        v.Add(vote);
                }
            }
        }

        public List<Vote> GetAllValidVotes()
        {
            return v;
        }

        public List<Vote> GetAllValidVotesForPart(string partShortName)
        {
            return v.Where(v1 => v1.PartShortName == partShortName).ToList();
        }
    }
}
