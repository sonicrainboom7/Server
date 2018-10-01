using System;
namespace ass3
{
     public class LogEntry
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime CreationTime { get; set; }
    }
}