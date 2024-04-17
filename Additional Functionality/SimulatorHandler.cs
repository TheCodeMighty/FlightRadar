using System.Text;
using NetworkSourceSimulator;
using OOD_Project1.Entities;
using OOD_Project1.MessageParsers;

namespace OOD_Project1
{
    public class SimulatorHandler
    {
        private Dictionary<string, MessageParser> parserMap = new Dictionary<string, MessageParser>()
        {
            { "NCR", new CrewParser() },
            { "NPA", new PassengerParser() },
            { "NCA", new CargoParser() },
            { "NCP", new CargoPlaneParser() },
            { "NPP", new PassengerPlaneParser() },
            { "NAI", new AirportParser() },
            { "NFL", new FlightParser() }
        };

        private NetworkSourceSimulator.NetworkSourceSimulator simulator;

        public SimulatorHandler(string ftrFilePath, int minDelay, int maxDelay)
        {
            simulator = new NetworkSourceSimulator.NetworkSourceSimulator(ftrFilePath, minDelay, maxDelay);
            simulator.OnNewDataReady += HandleNewData;
        }

        private void HandleNewData(object sender, NewDataReadyArgs e)
        {
            var message = simulator.GetMessageAt(e.MessageIndex);

            string identifier = Encoding.ASCII.GetString(message.MessageBytes, 0, 3);

            BaseEntity entity = parserMap[identifier].MessageParsing(message.MessageBytes);
            if (entity != null)
            {
                parserMap[identifier].AddParsedEntity(EntityStorage.GetInstance(), entity);
            }
        }

        public static void HandleSimulatorCommands()
        {
            string command;
            while ((command = Console.ReadLine()) != "exit")
            {
                if (command == "print")
                {
                    PrintCommand();
                }
                else if (command == "report")
                {
                    NewsGenerator.ReportCommand();
                }
            }
        }

        public static void PrintCommand()
        {
            string timestamp = DateTime.Now.ToString("HH_mm_ss");
            JsonDataWriter.SerializeToJson(EntityStorage.GetInstance(), $"snapshot_{timestamp}.json");
            Console.WriteLine($"Snapshot successfully created at {timestamp}.");
        }

        public void Start()
        {
            Task.Run(() => simulator.Run());
        }
    }
}
