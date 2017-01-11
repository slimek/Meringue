using UnityEngine;

namespace Meringue.Mvp
{
    public class View : MonoBehaviour
    {
        protected void Awake()
        {
            ViewManager.AddView(this);
        }
    }
} // namespace Meringue.Mvp
