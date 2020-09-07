using System;
namespace nibble.Interfaces
{
    public interface IToastService
    {
        void Toast(string message,ulong ms);
    }
}
