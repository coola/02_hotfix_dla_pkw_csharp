using System;
using System.Net;
using MasterCoder.PKW.Mandates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterCoder.PKW.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void file_name_validation_test()
        {
            const int maxComponent = 255;
            for (int c1 = 0; c1 <= maxComponent; ++c1)
                for (int c2 = 0; c2 <= maxComponent; ++c2)
                    for (int c3 = 0; c3 <= maxComponent; ++c3)
                        for (int c4 = 0; c4 <= maxComponent; ++c4)
                        {
                            var ipNumber = String.Format("{0}.{1}.{2}.{3}", c1, c2, c3, c4);
                            Assert.IsTrue(FileNameValidation.Validate(ipNumber),
                                String.Format("IP number {0} wasn't validated", ipNumber));
                        }
        }

        [TestMethod]
        public void file_name_validation_test_2()
        {
            const int maxComponent = 50;
            for (int c1 = 0; c1 <= maxComponent; ++c1)
                for (int c2 = 0; c2 <= maxComponent; ++c2)
                    for (int c3 = 0; c3 <= maxComponent; ++c3)
                        for (int c4 = 0; c4 <= maxComponent; ++c4)
                        {
                            var ipNumber = String.Format("{0}.{1}.{2}.{3}", c1, c2, c3, c4);
                            Assert.IsTrue(IsValidIp(ipNumber),
                                String.Format("IP number {0} wasn't validated", ipNumber));
                        }
        }

        public bool IsValidIp(string addr)
        {
            IPAddress ip;
            bool valid = !string.IsNullOrEmpty(addr) && IPAddress.TryParse(addr, out ip);
            return valid;
        }
    }
}