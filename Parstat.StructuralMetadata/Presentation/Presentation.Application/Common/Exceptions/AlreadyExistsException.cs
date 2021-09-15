using System;

namespace Presentation.Application.Common.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string name, object value)
            : base($"Entity \"{name}\" ({value}) already exists.")
        {
        }    
    }
}