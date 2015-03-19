using System.Net;
//ograniczenie nadmiarowych using'ów

namespace MasterCoder.PKW.Mandates
{
    public class FileNameValidation
    {
        //private static readonly string p = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

        //poprawa działania validacji numeru IP - metoda wykorzystująca powyższy regex jest wolniejsza niz użycie standardowej metody bibliotecznej
        public static bool Validate(string n)
        {
            IPAddress ip;
            return !string.IsNullOrEmpty(n) && IPAddress.TryParse(n, out ip);
        }
    }
}
