using System;

namespace Sidetech.Sne.Domain.Helpers.ResultHelpers
{
    public class OperationResult
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; } = 500; 
        public Exception Exception { get; set; }
    }
}
