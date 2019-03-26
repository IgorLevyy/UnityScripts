
using UnityEvent_Api;

public abstract class UnityEventServer
{
    public static UnityEventListenerJs GetUnityEventListenerJs()
    {
        return new UnityEventListenerJs();
    }

    //public static UnityEventListenerHttp GetUnityEventListenerHttp()
    //{
    //    return new UnityEventListenerHttp("127.0.0.1");
    //}

    public static IUnityEventListener GetUnityEventListener()
    {
         return GetUnityEventListenerJs();
    }
}

