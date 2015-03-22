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
                Validator.ValidateInputParameters(args);

                // wykorzystanie interfejsu zamiast implementacji
                IInputVotes votes = new InputVotes(args[2]);

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
