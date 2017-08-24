using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {
	static public PathFinder instance;
	[Range(1, 10)]
	public int size;
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

        for (int x = -size + 1; x < size; x++){
			
			for (int z = -size + 1; z < size; z++){
				
				Node nNode = new Node();
				Node nNode2 = new Node();
				nNode.SetPosition(new Vector3(x, 0, z));
				nNode2.SetPosition(new Vector3(x + 0.5f, 0, z + 0.5f));
               
			    if ((x == 5 && ( z < 5 || z > 5)) || (x == -4 && ( z < -6 || z > -6))){
					nNode.SetValue(0);
					nNode.SetValue(0);
				}
                else{
					nNode.SetValue(Random.Range(1, 3));
					nNode2.SetValue(Random.Range(1, 3));
				}
			    nodes.Add(nNode2);
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
					node.GetAdyacents()[i].AddTotalValue(Vector3.Distance(node.GetAdyacents()[i].GetPosition(), endNode.GetPosition()));
						
					
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
			Gizmos.DrawSphere(nodes[i].GetPosition(), 0.15f);
			Gizmos.color = Color.white;
			for (int j = 0; j < nodes[i].GetAdyacents().Count; j++){
				Gizmos.DrawLine(nodes[i].GetPosition(), nodes[i].GetAdyacents()[j].GetPosition());
			}
		}

		for (int i = 0; i < closedNodes.Count; i++){
			Gizmos.color = Color.magenta;
			Gizmos.DrawSphere(closedNodes[i].GetPosition(), 0.30f);
		}

		for (int i = 0; i < pathToCheck.Count; i++){
			Gizmos.color = Color.green;
			Gizmos.DrawSphere(pathToCheck[i].GetPosition(), 0.30f);
		}
	}
#endif
}
