using System;
using nibble.Interfaces;
using Xamarin.Forms;

namespace nibble.Services
{
    public class LocalStorageService:ILocalStorageService
    {
        public LocalStorageService()
        {

        }

        public object GetStorageByKey(string key)
        {
            if (!Application.Current.Properties.ContainsKey(key))
            {
                return false;
            }

            return Application.Current.Properties[key];
        }

        public void SetStorageWithKey(string key, object ob)
        {
            Application.Current.Properties[key] = ob;
            Application.Current.SavePropertiesAsync();
        }
    }
}
