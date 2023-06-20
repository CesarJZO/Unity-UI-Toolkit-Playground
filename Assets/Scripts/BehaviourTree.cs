using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BehaviourTree : ScriptableObject
{
    public Node rootNode;

    public List<Node> nodes = new List<Node>();

    public Node CreateNode(Type type)
    {
        var node = CreateInstance(type) as Node;
        node.name = type.Name;
        node.guid = Guid.NewGuid().ToString();
        nodes.Add(node);

        AssetDatabase.AddObjectToAsset(node, this);
        AssetDatabase.SaveAssets();
        return node;
    }

    public void DeleteNode(Node node)
    {
        nodes.Remove(node);
        AssetDatabase.RemoveObjectFromAsset(node);
        AssetDatabase.SaveAssets();
    }
}
