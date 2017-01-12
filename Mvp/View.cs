#if USE_UNI_RX

using UnityEngine;

namespace Meringue.Mvp
{
    public class View : MonoBehaviour
    {
        private void Awake()
        {
            ViewManager.AddView(this);

            this.OnAwake();
        }

        protected virtual void OnAwake() { }

    }
} // namespace Meringue.Mvp

#endif // USE_UNI_RX
