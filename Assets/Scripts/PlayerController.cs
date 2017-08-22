using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Stack<Node> path = new Stack<Node>();
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
			transform.LookAt(path.Peek().GetPosition());
			transform.position = Vector3.MoveTowards(transform.position, path.Peek().GetPosition(), speed * Time.deltaTime);

			if (Vector3.Distance(path.Peek().GetPosition(), transform.position) < 0.10f){
				path.Pop();
			}
		}
	}
}
