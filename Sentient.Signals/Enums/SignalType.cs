namespace Sentient.Signals.Enums
{
    /// <summary>
    /// This enum specifies the type of information that is being sent.
    /// </summary>
    public enum SignalType
    {
        None = 0,               // No signal
        Terminate = 1,          // node terminate operation
        Request = 2,            // internal input
        Response = 3,           // internal output
        Receive = 4,            // external input
        Transmit = 5,           // external output
        Search = 6,             // query information
        
    }

}
