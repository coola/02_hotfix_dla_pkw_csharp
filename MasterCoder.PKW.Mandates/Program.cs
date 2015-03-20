using System;
using System.Collections.Generic;
using System.IO;
//ograniczenie nadmiarowych using'ów

namespace MasterCoder.PKW.Mandates
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                ValidateInputParameters(args);
                InputVotes votes = new InputVotes(args[2]);

                IMandateMethod m = MandateMethodFactory.Get((MethodEnum)Int32.Parse(args[0]));
                var mandates = m.CalculateMandates(votes.GetAllValidVotes(), Int32.Parse(args[1]));
                ShowOnConsole(mandates);

                Console.ReadLine();
            }
            catch (InputParametersException)
            {
                Console.WriteLine("Input parameters are incorrect. No party gets mandate.");
            }
        }

        private static void ValidateInputParameters(string[] args)
        {
            if (args.Length != 3)
            {
                throw new InputParametersException("Parameters count error.");
            }

            uint test;
            if (!UInt32.TryParse(args[0], out test) || !UInt32.TryParse(args[1], out test))
            {
                //poprawa literówki w opisie błędu
                throw new InputParametersException("Parameter should be digit.");
            }

            if(string.IsNullOrWhiteSpace(args[2]) || !Directory.Exists(args[2]))
            {
                throw new InputParametersException("Wrong path name.");
            }
        }

        private static void ShowOnConsole(List<Mandate> mandates)
        {
            foreach (var mandate in mandates)
            {
                // wywołanie string.Format jest nadmiarowe w tym przypadku. Metoda Console.WriteLine już ma właściwości string.Format.
                // Z dokumentacji metody Console.WriteLine: "Writes out a formatted string and a new line.  Uses the same 
                // semantics as String.Format."
                Console.WriteLine("{0};{1};{2}", mandate.PartShortName, mandate.PartName, mandate.Mandates);
            }
        }
    }
}
