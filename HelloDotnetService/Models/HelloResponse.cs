namespace HelloDotnetService.Models
{

    /// <summary>
    /// Response from the Hello endpoint
    /// </summary>
    public sealed class HelloResponse
    {

        /// <summary>
        /// The message
        /// </summary>
        public string Message {get; set;}

        /// <summary>
        /// The name of the caller
        /// </summary>
        public string Name {get; set;}
    }
}