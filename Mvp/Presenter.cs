#if USE_UNI_RX

using System;

namespace Meringue.Mvp
{
    public class Presenter
    {
        public static PresenterInterface Create<PresenterInterface>()
        {
            var interfaceName = typeof(PresenterInterface).Name;

            if (!interfaceName.StartsWith("I"))
            {
                throw new NotSupportedException(
                    string.Format(
                        "Presenter interface name must start with \"I\", but given \"{0}\"",
                        interfaceName
                ));
            }

            var className = interfaceName.Substring(1);

            var stubClassName = "Stub" + className;
            var stubType = Type.GetType(stubClassName);
            if (stubType != null)
            {
                return (PresenterInterface)Activator.CreateInstance(stubType);
            }

            var type = Type.GetType(className);
            return (PresenterInterface)Activator.CreateInstance(type);
        }
    }
} // namespace Meringue.Mvp

#endif // USE_UNI_RX
