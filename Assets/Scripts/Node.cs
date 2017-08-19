using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node{
    Node parent;
    private List<Node> adyacents = new List<Node>();
    private Vector3 pos;

    public void AddAdyacent(Node ady) {
        adyacents.Add(ady);
    }

    public List<Node> GetAdyacents(){
        return adyacents;
    }

    public void SetParent(Node pNode) {
        parent = pNode;
    }

    public Node GetParent(){
        return parent;
    }

    public void SetPosition(Vector3 nPos) {
        pos = nPos;
    }

    public Vector3 GetPosition(){
        return pos;
    }

}
