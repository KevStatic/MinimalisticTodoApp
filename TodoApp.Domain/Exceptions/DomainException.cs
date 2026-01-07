using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Domain.Exceptions;

public sealed class DomainException : Exception
{
    public DomainException(string message) : base(message)
    {
    }
}
