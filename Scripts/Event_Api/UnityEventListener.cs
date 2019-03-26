using System;
using UnityEngine;

public class MessageSR
{
    public string ElementRef;
    public string ActionRef;
    public string InventoryItemRef;
}

namespace UnityEvent_Api
{
#pragma warning disable CS0618
    public interface IUnityEventListener
    {
        void OnEnable();
        void OnDisable();
        void SendMessageToSR(string elementRef, string actionRef, string inventoryItemRef);
    }

    public class UnityEventListenerJs : IUnityEventListener//: MonoBehaviour
    {
        public void SendMessageToSR(string elementRef, string actionRef, string inventoryItemRef)
        {
            MessageSR messageSR = new MessageSR
            {
                ElementRef = elementRef,
                ActionRef = actionRef,
                InventoryItemRef = inventoryItemRef
            };
            string strJson = JsonUtility.ToJson(messageSR);
            string strFunc = "ReceiveUnityMessage('" + strJson + "')";
            Application.ExternalCall(strFunc);
        }
        public void OnEnable()
        {
            ActivateScript.ClickActiveObjectEvent += OnClickActiveObject;
            Inventory.StartInventoryEvent += OnStartInventory;
            DialogScript.SelectDialogItemEvent += OnSelectDialogItem;
            Player.OnCollisionEvent += OnCollisionEnter;
        }
        public void OnDisable()
        {
            ActivateScript.ClickActiveObjectEvent -= OnClickActiveObject;
            Inventory.StartInventoryEvent -= OnStartInventory;
            Player.OnCollisionEvent -= OnCollisionEnter;
        }

        private void OnCollisionEnter(string objectName)
        {
            string funcExternal = string.Format("OnCollisionEnter({0})", new { ObjectId = objectName });
            Application.ExternalCall(funcExternal);
        }

        private void OnClickActiveObject(string objectId, string subjectId)
        {
            // send to server
            // например, 
            //  string funcExternal = string.Format("OnClickActiveObject({0}, {1})", objectId, subjectId);
            //  Application.ExternalCall(funcExternal);

            //или так
            string funcExternal = string.Format("OnClickActiveObject({0})", new { ObjectId = objectId, SubjectId = subjectId });
            Application.ExternalCall(funcExternal);
        }

        private void OnSelectDialogItem(int dialogCode, int keyItem)
        {
            string funcExternal = string.Format("OnSelectDialogItem({0})", JsonUtility.ToJson(new { DialogCode = dialogCode, KeyItem = keyItem }));
            Application.ExternalCall(funcExternal);
        }

        private void OnStartInventory()
        {
            string funcExternal = string.Format("OnStartInventory()");
            Application.ExternalCall(funcExternal);
        }

    }

    //public class UnityEventListenerHttp : IUnityEventListener
    //{
    //    private UnityWebRequestScript _unityWebRequestScript;
    //    public UnityEventListenerHttp(string urlServer)
    //    {
    //        GameObject UnityWebRequestGameObject = GameObject.Find("UnityWebRequestGameObject");
    //        _unityWebRequestScript = UnityWebRequestGameObject.GetComponent<UnityWebRequestScript>();
    //        _unityWebRequestScript.UrlServer = urlServer;
    //    }
    //    public void OnEnable()
    //    {
    //        ActivateScript.ClickActiveObjectEvent += OnClickActiveObjectEvent;
    //    }
    //    public void OnDisable()
    //    {
    //        ActivateScript.ClickActiveObjectEvent -= OnClickActiveObjectEvent;
    //    }

    //    private void OnClickActiveObjectEvent(string objectId, string subjectId)
    //    {                 
    //        _unityWebRequestScript.PostWebRequest("OnClickActiveObject", (new { ObjectId = objectId, SubjectId = subjectId }).ToString());
    //    }
    //}

}
