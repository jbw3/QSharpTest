using System;
using Microsoft.Quantum.Simulation.Common;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace QSharpTest
{
    public class Driver
    {
        public static void Main(string[] args)
        {
            // RunResourcesEstimator();
            RunQuantumSimulator();
        }

        private static void RunResourcesEstimator()
        {
            var estimator = new ResourcesEstimator();
            Run(estimator);

            Console.WriteLine(estimator.ToTSV());
        }

        private static void RunQuantumSimulator()
        {
            using (var qsim = new QuantumSimulator())
            {
                Run(qsim);
            }
        }

        private static void Run(SimulatorBase simulator)
        {
            RunTest(simulator);
            // RunBellTest(simulator);
        }

        private static void RunTest(SimulatorBase simulator)
        {
            // Try initial values
            Result[] initials = new Result[] { Result.Zero, Result.One };
            foreach (Result initial in initials)
            {
                var res = Test.Run(simulator, 1000, initial).Result;
                var (numZeros, numOnes) = res;
                Console.WriteLine($"Init:{initial,-4} 0s={numZeros,-4} 1s={numOnes,-4}");
            }
        }

        private static void RunBellTest(SimulatorBase simulator)
        {
            // Try initial values
            Result[] initials = new Result[] { Result.Zero, Result.One };
            foreach (Result initial in initials)
            {
                var res = BellTest.Run(simulator, 1000, initial).Result;
                var (numZeros, numOnes, agree) = res;
                Console.WriteLine($"Init:{initial,-4} 0s={numZeros,-4} 1s={numOnes,-4} agree={agree,-4}");
            }
        }
    }
}
