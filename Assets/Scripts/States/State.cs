using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State{
	protected FSM fsm;
	protected Transform transform;
	public State(Transform obj, FSM fsm){
		this.transform = obj;
		this.fsm = fsm;
	}

	virtual public void Play(){}
}
