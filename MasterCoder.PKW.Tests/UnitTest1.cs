using System;
using System.IO;
using System.Reflection;
using MasterCoder.PKW.Mandates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasterCoder.PKW.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Ignore]
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



        internal class InputParametersException : Exception
        {
            public InputParametersException(string message)
                : base(message)
            {
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

            if (string.IsNullOrWhiteSpace(args[2]) || !Directory.Exists(args[2]))
            {
                throw new InputParametersException("Wrong path name.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InputParametersException))]
        public void input_parameters_validation_test()
        {

            ValidateInputParameters(new string[] { });

        }

        [TestMethod]
        [ExpectedException(typeof(InputParametersException))]
        public void input_parameters_validation_test_2()
        {
            ValidateInputParameters(new [] { "","",""});
        }

        [TestMethod]
        public void input_parameters_validation_test_3()
        {
            ValidateInputParameters(new[] { "4", "1", "c:\\data" });
        }

        [TestMethod]
        [ExpectedException(typeof(InputParametersException))]
        public void input_parameters_validation_test_4()
        {
            ValidateInputParameters(new[] { "-4", "-1", "c:\\data" });
        }

    }
}