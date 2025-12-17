using System;

namespace Ototeks.Interfaces // veya Interfaces
{
    // Bu arayüzü uygulayan her Form, mutlaka "OperationCompleted" olayına sahip olmak zorundadır.
    public interface IOperationForm
    {
        event EventHandler OperationCompleted; // Eski adıyla: IslemYapildi
    }
}