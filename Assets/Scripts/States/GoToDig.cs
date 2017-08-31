using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToDig : State {
	private Vector3 target;
	private Stack<Node> path = new Stack<Node>();
	private float speed;
	private bool going = false; 
	public GoToDig(Transform obj, FSM fsm) : base(obj, fsm) {}

	override public void Play(){
		if (!going){
			path = PathFinder.instance.FindPhat(transform.position, target);
		}

		if (path != null && path.Count > 0){
			going = true;
			
			transform.LookAt(path.Peek().GetPosition());
			transform.position = Vector3.MoveTowards(transform.position, path.Peek().GetPosition(), speed * Time.deltaTime);

			if (Vector3.Distance(path.Peek().GetPosition(), transform.position) < 0.10f){
				path.Pop();
				if (path.Count < 1){
					fsm.ReceiveEvent((int)PlayerController.Events.Arrived);
				}
			}
		}
	}

	public void SetTarget(Vector3 posTarget){
		target = posTarget;
		target.y = 0;
	}

	public void SetSpeed(float speed){
		this.speed = speed;
	}
}
