#if USE_UNI_RX

using System.Collections;
using UnityEngine;
using UniRx;

namespace Meringue.Mvp
{
    public class Scene : MonoBehaviour
    {
        protected IObservable<View> LoadView(string viewName)
        {
            var observable = Observable.FromCoroutine(() => LoadViewAsync(viewName));

            return observable.Select(_ => ViewManager.FindView(viewName + "View"));
        }

        private IEnumerator LoadViewAsync(string viewName)
        {
            var asyncOp = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(
                viewName,
                UnityEngine.SceneManagement.LoadSceneMode.Additive
            );

            yield return asyncOp;
        }
    }
} // namespace Meringue.Mvp

#endif // USE_UNI_RX
