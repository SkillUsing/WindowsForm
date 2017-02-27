using System.Drawing;
using System.Globalization;
using System.Resources;

namespace WindowForms
{
    public class Resources
    {
        private static ResourceManager _resourceMan;
        private static CultureInfo _resourceCulture;

        internal static ResourceManager ResourceManager
        {
            get
            {
                if (!ReferenceEquals(_resourceMan, null)) return _resourceMan;
                var resourceManager = new ResourceManager("DHQ.Windows.Resources", typeof(Resources).Assembly);
                _resourceMan = resourceManager;
                return _resourceMan;
            }
        }
        internal static Bitmap Drag
        {
            get
            {
                var @object = ResourceManager.GetObject("drag", _resourceCulture);
                return (Bitmap)@object;
            }
        }
        internal static Bitmap Drag2
        {
            get
            {
                var @object = ResourceManager.GetObject("drag2", _resourceCulture);
                return (Bitmap)@object;
            }
        }
        internal static byte[] Eye
        {
            get
            {
                var @object = ResourceManager.GetObject("eye", _resourceCulture);
                return (byte[])@object;
            }
        }
    }
}
