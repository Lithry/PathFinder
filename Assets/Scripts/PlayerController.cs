using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private List<Node> path = new List<Node>();
	public float speed;
	public Vector3 moveTo;
	public bool search;
	void Start () {
		search = false;
		speed = 4;
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move(){
		if (search){
			search = false;
			path.Clear();
			path = PathFinder.instance.FindPhat(transform.position, moveTo);
		}

		if (path != null || path.Count > 0){
			transform.LookAt(path[0].GetPosition());
			transform.position = Vector3.MoveTowards(transform.position, path[0].GetPosition(), speed * Time.deltaTime);

			if (Vector3.Distance(path[0].GetPosition(), transform.position) < 0.10f){
				path.Remove(path[0]);
			}
		}
	}

#if   UNITY_EDITOR    
	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		for (int i = 0; i < path.Count; i++){
			Gizmos.DrawSphere(path[i].GetPosition(), 0.25f);
			for (int j = 0; j < path[i].GetAdyacents().Count; j++){
				Gizmos.DrawLine(path[i].GetPosition(), path[i].GetAdyacents()[j].GetPosition());
			}
		}
	}
#endif
}
