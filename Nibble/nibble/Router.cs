using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using nibble.Attributes;
using nibble.Pages.Home;
using nibble.ViewModels.Home;
using nibble.ViewModels;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace nibble
{
    public class Router
    {
        private static Dictionary<string, Type> PathTypeMap = new Dictionary<string, Type>();
        private static Dictionary<string, Func<object[],object>> PathActionMap = new Dictionary<string, Func<object[],object>>();

        public static void RegisterPaths()
        {
            var types = GetAttributedTypes();
            foreach (var type in types)
            {
                var attribute = Attribute.GetCustomAttributes(type).First(a => a is RouterAttribute);
                var path = ((RouterAttribute)attribute).Path;
                PathTypeMap.Add(path, type);
            }
        }

        public static void RegisterAction(string path,Func<object[],object> action)
        {
            PathActionMap.Add(path,action);
        }

        public static object Action(string path,object[] parameters)
        {
            var action = PathActionMap[path];
            if (action == null)
            {
                Debug.Fail(string.Format("your forgot to register action for path {0} ", path));
                return null;
            }
            else
            {
                return action(parameters);
            }
        }

        public static Task Navigate(string path,object obj)
        {
            var pageType = PathTypeMap[path];
            if (pageType == null)
            {
                Debug.Fail(string.Format("your forgot to attribute path {0} on your page", path));
                return null;
            }
            else
            {
                var page = Activator.CreateInstance(pageType, new object[] { obj }) as Page;
                return GetActivePage().Navigation.PushAsync(page);
            }
            
        }

        public static Task Pop()
        {
            return GetActivePage().Navigation.PopAsync();
        }

        public static void Switch(string path, object obj)
        {
            var pageType = PathTypeMap[path];
            if (pageType == null)
            {
                Debug.Fail(string.Format("your forgot to attribute path {0} on your page", path));
            }
            else
            {
                var page = Activator.CreateInstance(pageType, new object[] { obj }) as Page;
                Application.Current.MainPage = page;
            }

        }

        private static Type[] GetAttributedTypes()
        {

            System.Reflection.Assembly asm = System.Reflection.Assembly.GetAssembly(typeof(RouterAttribute));
            Type[] types = asm.GetExportedTypes();

            Func<Attribute[], bool> IsMyAttribute = o =>
            {
                foreach (Attribute a in o)
                {
                    if (a is RouterAttribute)
                        return true;
                }
                return false;
            };

            return types.Where(o =>
            {
                return IsMyAttribute(System.Attribute.GetCustomAttributes(o, true));
            }
            ).ToArray();

        }

        public static Page GetActivePage()
        {
            var mainPage = Application.Current.MainPage;

            //if current mainPage is tabbedPage
            if (mainPage is TabbedPage)
            {
                return ((TabbedPage)mainPage).CurrentPage;
            }
            // else mainPage is not tabbedPage
            else
            {
                return Application.Current.MainPage;
            }
        }
    }
}
