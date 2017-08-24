using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {
	static public PathFinder instance;
    private List<Node> nodes = new List<Node>();
    private List<Node> openNodes = new List<Node>();
    private List<Node> closedNodes = new List<Node>();
    //private List<Node> path = new List<Node>();
	private Stack<Node> path = new Stack<Node>();
	private List<Node> pathToCheck = new List<Node>();
    private Node startNode;
    private Node endNode;

    void Start () {
        instance = this;

        for (int x = 0; x < 10; x++){
			for (int z = 0; z < 10; z++){
				Node nNode = new Node();
				nNode.SetPosition(new Vector3(x, 0, z));
                switch (x)
                {
                    case 5 when z < 5 || z > 5:
                        nNode.SetValue(0);
                        break;
                    default:
                        nNode.SetValue(Random.Range(1, 3));
                        break;
                }

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
	
    public Stack<Node> FindPhat(Vector3 beginPos, Vector3 endPos) {
		if (nodes == null || nodes.Count == 0){
			return null;
		}

		ClearNodeData();
		
		for(int i = 0; i < nodes.Count; i++){
			if (nodes[i].GetValue() != 0){
				startNode = nodes[i];
				endNode = nodes[i];
				break;
			}
		}
		
		for (int i = 0; i < nodes.Count; i++){
			if (Vector3.Distance(startNode.GetPosition(), beginPos) > (Vector3.Distance(nodes[i].GetPosition(), beginPos)) && nodes[i].GetValue() != 0){
				startNode = nodes[i];
			}

			if (Vector3.Distance(endNode.GetPosition(), endPos) > (Vector3.Distance(nodes[i].GetPosition(), endPos)) && nodes[i].GetValue() != 0){
				endNode = nodes[i];
			}
		}
		
		return SearchPath(startNode);
    }
	
    private Stack<Node> SearchPath(Node node) {
		openNodes.Add(node);
		
		while(openNodes.Count > 0){
			if (node.GetPosition() == endNode.GetPosition()){
				while (node.GetParent() != null){
					path.Push(node);
					pathToCheck.Add(node);
					node = node.GetParent();
				}
				return path;
			}

			openNodes.Remove(node);
			closedNodes.Add(node);
			
			for(int i = 0; i < node.GetAdyacents().Count; i++){
				if (!closedNodes.Contains(node.GetAdyacents()[i]) && !openNodes.Contains(node.GetAdyacents()[i]) && node.GetAdyacents()[i].GetValue() != 0){
					openNodes.Add(node.GetAdyacents()[i]);
					node.GetAdyacents()[i].SetParentAndParentTotalValue(node);
				}
			}

			node = openNodes[0];
			for(int i = 0; i < openNodes.Count; i++){
				if (node.GetTotalValue() > openNodes[i].GetTotalValue() && openNodes[i].GetValue() != 0)
					node = openNodes[i];
			}
		}
		return null;
    }

	private void ClearNodeData(){
		path.Clear();
		pathToCheck.Clear();
		openNodes.Clear();
		closedNodes.Clear();

		for(int i = 0; i < nodes.Count; i++){
			nodes[i].SetParent(null);
			nodes[i].ResetTotalValue();
		}
	}

#if   UNITY_EDITOR    
	void OnDrawGizmos(){
		for (int i = 0; i < nodes.Count; i++){
			if (nodes[i].GetValue() == 0)
				Gizmos.color = Color.red;
			else if (nodes[i].GetValue() == 1)
				Gizmos.color = Color.white;
			else
				Gizmos.color = Color.grey;
			Gizmos.DrawSphere(nodes[i].GetPosition(), 0.25f);
			Gizmos.color = Color.white;
			for (int j = 0; j < nodes[i].GetAdyacents().Count; j++){
				Gizmos.DrawLine(nodes[i].GetPosition(), nodes[i].GetAdyacents()[j].GetPosition());
			}
		}
	}
#endif
}
