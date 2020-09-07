using System;
using Xamarin.Forms;

namespace nibble.Interfaces
{
    public interface ILocalStorageService
    {
        object GetStorageByKey(string key);
        void SetStorageWithKey(string key, object ob);
    }
}
