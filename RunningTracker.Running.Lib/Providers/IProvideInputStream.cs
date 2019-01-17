using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace RunningTracker.Running.Providers
{
    public interface IProvideInputStream
    {
         Stream GetStream();
         IEnumerable<Stream> GetStreams();
    }

    public class InputStreamProvider : IProvideInputStream
    {
        public Stream GetStream()
        {
            throw new NotImplementedException();            
        }

        public IEnumerable<Stream> GetStreams()
        {
            throw new NotImplementedException();
        }
    }
}