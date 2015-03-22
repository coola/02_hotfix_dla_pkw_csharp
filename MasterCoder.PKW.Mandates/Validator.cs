using System;
using System.IO;

namespace MasterCoder.PKW.Mandates
{
	// wyniesienie walidacji do klasy - zapewnienie Single Responisbility Principle 
    // oprócz tego to pomaga w testowaniu jednostkowym
	public static class Validator
	{
		public static void ValidateInputParameters(string[] args)
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
		
	}
}
