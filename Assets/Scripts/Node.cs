using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node{
    private Node parent;
    private List<Node> adyacents = new List<Node>();
    private Vector3 pos;
    private int value;
    private int totalValue;

    public void AddAdyacent(Node ady) {
        adyacents.Add(ady);
    }

    public List<Node> GetAdyacents(){
        return adyacents;
    }

    public void SetParent(Node pNode) {
        parent = pNode;
    }

    public void SetParentAndParentTotalValue(Node pNode) {
        parent = pNode;
        totalValue += pNode.GetTotalValue();
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

    public void SetValue(int val){
        value = val;
    }

    public int GetValue(){
        return value;
    }

    public void AddTotalValue(int val){
        totalValue += val;
    }

    public void ResetTotalValue(){
        totalValue = value;
    }

    public int GetTotalValue(){
        return totalValue;
    }

}
