namespace HelloDotnetService.Models
{
    using System;

    /// <summary>
    /// Response from the Ping endpoint
    /// </summary>
    public sealed class PingResponse
    {

        /// <summary>
        /// Ping response message
        /// </summary>
        public string Message {get; set;}

        /// <summary>
        /// Date time of the response
        /// </summary>
        public DateTime Time {get; set;}
    }
}