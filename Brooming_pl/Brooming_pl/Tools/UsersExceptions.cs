
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brooming_pl.Tools
{
    public class UsersExceptions : System.Exception
    {
        public UsersExceptions() : base() { }
        public UsersExceptions(string message) : base(message) { }
        public UsersExceptions(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected UsersExceptions(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
