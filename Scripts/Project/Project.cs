using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EProjectNS
{


    public class Inventory
    {
        public List<InventoryItem> InventoryItems { get; set; }
        public InventoryItem GetInventoryItem(string Id)
        {
            return InventoryItems.Find(x => x.Id == Id);
        }
        public void Init()
        {
            //InventoryItems.RemoveAll(x => true);

            //InventoryItems = new List<InventoryItem>();
            //GameObject gameObjectInventory = GameObject.Find("table");
            //Transform transform = gameObjectInventory.transform.Find("Object");
            //GameObject gameObjectChild;
            //for (int i = 0; i < transform.childCount; i++)
            //{
            //    gameObjectChild = transform.GetChild(i).gameObject;
            //    InventoryItem inventoryItem = new InventoryItem
            //    {
            //        Id = gameObjectChild.name,
            //        Title = gameObjectChild.name,
            //    };
            //    InventoryItems.Add(inventoryItem);
            //}
        }
    }


    public class InventoryItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public Texture2D Texture { get; set; }
    }


    public class EProject
    {
        public int ProjectId { get; set; }
        public string TaskTitle { get; set; }
        public bool IsStart { get; set; }

        public Inventory Inventory { get; set; }
        public InventoryItem InventoryItemCurrent { get; set; }
        public GameObject GameObjectInventoryItemCurrent { get; set; }


        public void Init()
        {
            IsStart = false;
            Inventory = new Inventory();
            Inventory.Init();
            TaskTitle = "Вывести в ремонт трансформатор 10/0,4 кВ на КТП 10/0,4 кВ";    
        }  

        public void Start()
        {
            Init();
        }
        public void Stop()
        {

        }

        public string GetReport()
        {
            // GUILayout.Label("<size=30>Some <color=yellow>RICH</color> text</size>", style2);
            string reportResult = "";
            reportResult += "<size=30><color=white>Результат выполнения: </color></size>";
            reportResult += "<size=20><color=white>";
            
            reportResult += "</color></size>";
            return reportResult;
        }


        public string GetLogActions()
        {
            return "";
        }

        public void CallServerMethod_DoAction(string ModelTreeNodeGuid, string ActionGuid, int value)
        {
            string method = string.Format("DoAction('{0}','{1}', {2})", ModelTreeNodeGuid, ActionGuid, value);
            Application.ExternalCall(method);
        }


    }

}
