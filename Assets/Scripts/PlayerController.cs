using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Transform tran;
	private List<Node> path = new List<Node>();
	public float speed;
	public Vector3 moveTo;
	public bool search;
	void Start () {
		tran = transform;
		search = false;
		speed = 10;
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move(){
		if (search){
			search = false;
			path = PathFinder.instance.FindPhat(tran.position, moveTo);
		}

		if (path != null || path.Count > 0){
			tran.LookAt(path[0].GetPosition());
			tran.Translate(Vector3.forward * speed * Time.deltaTime);

			if (Vector3.Distance(path[0].GetPosition(), tran.position) < 0.10f){
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
