using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {
	static public PathFinder instance;
    private List<Node> nodes = new List<Node>();
    private List<Node> openNodes = new List<Node>();
    private List<Node> closedNodes = new List<Node>();
    private List<Node> path = new List<Node>();
    private Node startNode;
    private Node endNode;

    void Start () {
        instance = this;

        for (int x = -10; x < 10; x++){
			for (int z = -10; z < 10; z++){
				Node nNode = new Node();
				nNode.SetPosition(new Vector3(x, 0, z));
				nodes.Add(nNode);
			}
		}

		for (int i = 0; i< nodes.Count; i++){
			for (int j = 0; j< nodes.Count; j++){
				if (nodes[i] != nodes[j]){
					if (Vector3.Distance(nodes[i].GetPosition(), nodes[j].GetPosition()) <= 1){
						nodes[i].AddAdyacent(nodes[j]);
					}
				}
			}
		}
    }
	
    public void FindPhat(Vector3 beginPos, Vector3 endPos) {

    }
	
    private void OpenNode(Node node) {

    }
#if   UNITY_EDITOR    
	void OnDrawGizmos(){
		Gizmos.color = Color.white;
		for (int i = 0; i < nodes.Count; i++){
			Gizmos.DrawSphere(nodes[i].GetPosition(), 0.25f);
			for (int j = 0; j < nodes[i].GetAdyacents().Count; j++){
				Gizmos.DrawLine(nodes[i].GetPosition(), nodes[i].GetAdyacents()[j].GetPosition());
			}
		}
	}
#endif
}
