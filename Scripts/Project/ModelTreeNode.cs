using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EProjectNS
{

    public class ModelTreeNodeActionType
    {
        public int Guid { get; set; }
        public string Title { get; set; }
    }

    public class ModelTreeNodeAction
    {
        public int Guid { get; set; }
        public string Title { get; set; }
        public int ActionType { get; set; }
        //public ScenarioAction ScenarioActionLink { get; set; }
        public bool IsVkl { get; set; }

        public string GameObjectToolTitle { get; set; }
        public GameObject GameObjectTool { get; set; }
    }

    public class ModelTreeNode
    {
        public int Guid { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Decription { get; set; }
        public List<ModelTreeNodeAction> ModelTreeNodeActions { get; set; }
        public int ModelTreeNodeTypee { get; set; }

    }
}

