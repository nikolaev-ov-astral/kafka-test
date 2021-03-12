
using System.Threading.Tasks;

namespace KafkaTest
{
    static internal class Program
    {
        static private async Task Main(string[] args)
        {
            await KafkaTestProgram.Start(args);
            // CheckImageAttributesProgram.Start(args);
            // TestDicom48bpp.Start(args);
        }
    }
}