#define Stage1
#define Stage2and4
#define Stage3

using FlightTrackerGUI;
using OOD_Project1.Entities;

namespace OOD_Project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if Stage1
            Thread ftrReaderThread = new Thread(() =>
            {
                string dataFile = "example_data.ftr";

                string outputPath = "output.json";

                string ftrPath = FilePathFinder.FindFilePath(dataFile);

                EntityStorage storage = EntityStorage.GetInstance();
                storage = DataLoader.LoadData(ftrPath);

                JsonDataWriter.SerializeToJson(EntityStorage.GetInstance(), outputPath);

                Console.WriteLine("Data loaded successfully");
            });
            ftrReaderThread.Start();

#endif
#if Stage2and4
            Console.WriteLine("enter \'print\' to make a snapshot of the .json file\n" +
                "enter \'report\' to see reports about objects\n" +
                "enter \'exit\' to finish working with command line");

            string simulatorDataFile = "example_data.ftr";

            string sumulatorFtrPath = FilePathFinder.FindFilePath(simulatorDataFile);

            // Initialize the simulator
            var simulatorHandler = new SimulatorHandler(sumulatorFtrPath, 1, 1);

            // Start the simulator in a separate task
            simulatorHandler.Start();

            Thread binaryReaderThread = new Thread(() =>
            {
                SimulatorHandler.HandleSimulatorCommands();
            });

            binaryReaderThread.Start();
#endif
#if Stage3
            Thread runGUIThread = new Thread(() =>
            {
                Runner.Run();
            });

            runGUIThread.Start();

            Thread updateGUIThread = new Thread(() =>
            {
                GUIUpdater.GUIUpdate();
            });

            updateGUIThread.Start();

            binaryReaderThread.Interrupt();
            runGUIThread.Interrupt();
            updateGUIThread.Interrupt();
            ftrReaderThread.Interrupt();
#endif
        }
    }
}