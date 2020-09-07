using System;
namespace nibble.Events
{
    public class TransactionNameEventArgs: EventArgs
    {

        public string Name { get; set; }

        public TransactionNameEventArgs()
        {
        }
    }
}
