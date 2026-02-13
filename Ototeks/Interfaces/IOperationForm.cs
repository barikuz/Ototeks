using System;

namespace Ototeks.Interfaces
{
    // Any Form implementing this interface must have an "OperationCompleted" event.
    public interface IOperationForm
    {
        event EventHandler OperationCompleted;
    }
}
