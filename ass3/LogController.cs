using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace ass3
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController
    {
        LogProcessor _processor;

        public LogController(LogProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet]
        public Task<LogEntry[]> GetLog()
        {
            return _processor.GetLog();
        }
    }
}