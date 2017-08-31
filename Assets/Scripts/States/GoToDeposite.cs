using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToDeposite : State {
	private Vector3 target;
	
	public GoToDeposite(Transform obj, FSM fsm) : base(obj, fsm) {}
	// Use this for initialization

	override public void Play(){
		
	}

	public void SetTarget(Vector3 posTarget){
		target = posTarget;
		target.y = 0;
	}
}
