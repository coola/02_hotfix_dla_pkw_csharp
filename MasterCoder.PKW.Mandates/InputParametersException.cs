using System;
//ograniczenie nadmiarowych using'ów

namespace MasterCoder.PKW.Mandates
{
    internal class InputParametersException : Exception
    {
        public InputParametersException(string message)
            : base(message)
        {
        }
    }
}
