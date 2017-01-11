using System.Collections.Generic;

namespace Meringue.Mvp
{
    public class ViewManager
    {
        // Singleton

        public static ViewManager instance { get { return _instance; } }
        private static readonly ViewManager _instance = new ViewManager();

        // Fields

        private Dictionary<string, View> _views = new Dictionary<string, View>();
        
        static ViewManager() { }
        private ViewManager() { }

        internal static void AddView(View view)
        {
            instance._views.Add(view.name, view);
        }

        internal static View FindView(string viewName)
        {
            return instance._views[viewName];
        }
    }
} // namespace Meringue.Mvp