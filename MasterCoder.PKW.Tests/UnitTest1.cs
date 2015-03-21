using System;
using MasterCoder.PKW.Mandates;
using System.Collections.Generic;
using NUnit.Framework;

namespace MasterCoder.PKW.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase]
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



        [TestCase]
        [ExpectedException(typeof (InputParametersException))]
        public void input_parameters_validation_test()
        {

            Validator.ValidateInputParameters(new string[] {});

        }

        [TestCase]
        [ExpectedException(typeof (InputParametersException))]
        public void input_parameters_validation_test_2()
        {
            Validator.ValidateInputParameters(new[] {"", "", ""});
        }

        [TestCase]
        public void input_parameters_validation_test_3()
        {
            Validator.ValidateInputParameters(new[] {"4", "1", "c:\\"});
        }

        [TestCase]
        [ExpectedException(typeof (InputParametersException))]
        public void input_parameters_validation_test_4()
        {
            Validator.ValidateInputParameters(new[] {"-4", "-1", "c:\\"});
        }

        [TestCase]
        [ExpectedException(typeof (InputParametersException))]
        public void input_parameters_validation_test_5()
        {
            Validator.ValidateInputParameters(new[] {"4", "1", " "});
        }

        [TestCase]
        [ExpectedException(typeof (InputParametersException))]
        public void input_parameters_validation_test_6()
        {
            Validator.ValidateInputParameters(new[] {"4", "1", "sdfsdfsd"});
        }

        [TestCase]
        public void test_method_dhondta_2()
        {
            var methodHondt = new MandateMethodDHondta();
            var votes = new List<Vote>
            {
                new Vote {PartShortName = "PO", PartName = "Platforma Obywatelska", ValidVotes = 1228},
                new Vote {PartShortName = "PIS", PartName = "Prawo i Sprawiedliwość", ValidVotes = 1012},
                new Vote {PartShortName = "PSL", PartName = "Polskie Stronnictwo Ludowe", ValidVotes = 850},
                new Vote {PartShortName = "SLD", PartName = "Sojusz Lewicy Demokratycznej", ValidVotes = 543},
                new Vote {PartShortName = "NP", PartName = "Nowa Prawica", ValidVotes = 352}
            };

            var calculateMandates = methodHondt.CalculateMandates(votes, 7);

            foreach (var mandate in calculateMandates)
            {
                if (mandate.PartShortName == "PO")
                {
                    Assert.AreEqual(2, mandate.Mandates);
                }

                if (mandate.PartShortName == "PIS")
                {
                    Assert.AreEqual(2, mandate.Mandates);
                }

                if (mandate.PartShortName == "PSL")
                {
                    Assert.AreEqual(2, mandate.Mandates);
                }

                if (mandate.PartShortName == "SLD")
                {
                    Assert.AreEqual(1, mandate.Mandates);
                }

                if (mandate.PartShortName == "NP")
                {
                    Assert.AreEqual(0, mandate.Mandates);
                }

            }

        }

        [TestCase]
        public void test_method_dhondta_1()
        {
            var methodHondt = new MandateMethodDHondta();
            Assert.IsNotNull(methodHondt);

            var votes = new List<Vote>
            {
                new Vote {PartShortName = "PO", PartName = "Platforma Obywatelska", ValidVotes = 720},
                new Vote {PartShortName = "PIS", PartName = "Prawo i Sprawiedliwość", ValidVotes = 300},
                new Vote {PartShortName = "PSL", PartName = "Polskie Stronnictwo Ludowe", ValidVotes = 480}
            };

            Assert.IsNotNull(votes);

            var partMandates = methodHondt.InitializeMandates(votes);

            Assert.IsNotNull(partMandates);

            var calculateMandates = methodHondt.CalculateMandates(votes, 8);

            Assert.IsNotNull(calculateMandates);

            foreach (var mandate in calculateMandates)
            {
                if (mandate.PartShortName == "PO")
                {
                    Assert.AreEqual(4, mandate.Mandates);
                }

                if (mandate.PartShortName == "PIS")
                {
                    Assert.AreEqual(1, mandate.Mandates);
                }

                if (mandate.PartShortName == "PSL")
                {
                    Assert.AreEqual(3, mandate.Mandates);
                }

            }
        }

        [TestCase]
        public void test_method_SaintLague_1()
        {
            var mandateMethodSainteLague = new MandateMethodSainteLague();

            var votes = new List<Vote>
            {
                new Vote {PartShortName = "PO", PartName = "Platforma Obywatelska", ValidVotes = 1228},
                new Vote {PartShortName = "PIS", PartName = "Prawo i Sprawiedliwość", ValidVotes = 1012},
                new Vote {PartShortName = "PSL", PartName = "Polskie Stronnictwo Ludowe", ValidVotes = 850},
                new Vote {PartShortName = "SLD", PartName = "Sojusz Lewicy Demokratycznej", ValidVotes = 543},
                new Vote {PartShortName = "NP", PartName = "Nowa Prawica", ValidVotes = 352}
            };

            var calculateMandates = mandateMethodSainteLague.CalculateMandates(votes, 7);

            foreach (var mandate in calculateMandates)
            {
                if (mandate.PartShortName == "PO")
                {
                    Assert.AreEqual(2, mandate.Mandates);
                }

                if (mandate.PartShortName == "PIS")
                {
                    Assert.AreEqual(2, mandate.Mandates);
                }

                if (mandate.PartShortName == "PSL")
                {
                    Assert.AreEqual(1, mandate.Mandates);
                }

                if (mandate.PartShortName == "SLD")
                {
                    Assert.AreEqual(1, mandate.Mandates);
                }

                if (mandate.PartShortName == "NP")
                {
                    Assert.AreEqual(1, mandate.Mandates);
                }
            }

        }

        [TestCase]
        public void test_method_HareNiemeyer_1()
        {
            var methodHareNiemeyer = new MandateMethodHareNiemeyer();

            var votes = new List<Vote>
            {
                new Vote {PartShortName = "PO", PartName = "Platforma Obywatelska", ValidVotes = 1228},
                new Vote {PartShortName = "PIS", PartName = "Prawo i Sprawiedliwość", ValidVotes = 1012},
                new Vote {PartShortName = "PSL", PartName = "Polskie Stronnictwo Ludowe", ValidVotes = 850},
                new Vote {PartShortName = "SLD", PartName = "Sojusz Lewicy Demokratycznej", ValidVotes = 543},
                new Vote {PartShortName = "NP", PartName = "Nowa Prawica", ValidVotes = 352}
            };

            var calculateMandates = methodHareNiemeyer.CalculateMandates(votes, 7);

            foreach (var mandate in calculateMandates)
            {
                if (mandate.PartShortName == "PO")
                {
                    Assert.AreEqual(2, mandate.Mandates);
                }

                if (mandate.PartShortName == "PIS")
                {
                    Assert.AreEqual(2, mandate.Mandates);
                }

                if (mandate.PartShortName == "PSL")
                {
                    Assert.AreEqual(1, mandate.Mandates);
                }

                if (mandate.PartShortName == "SLD")
                {
                    Assert.AreEqual(1, mandate.Mandates);
                }

                if (mandate.PartShortName == "NP")
                {
                    Assert.AreEqual(1, mandate.Mandates);
                }
            }

        }
    }
}