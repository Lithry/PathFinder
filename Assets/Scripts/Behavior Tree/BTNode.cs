using System.Collections;
using System.Collections.Generic;

abstract public class BTNode<T>{
	public enum State{
		Sleep = 0,
		False,
		True,
		Executing
	}

	protected State status;
	protected State lastStatus;
	protected T blackboard;

	public BTNode(T blackboard){
		this.blackboard = blackboard;
	}

	abstract protected void Awake();

	abstract protected State Execute();

	abstract protected void Reset();

	public State Play(){
		if (status == State.Sleep)
		{
			Awake();
			lastStatus = status = State.Executing;
		}

		lastStatus = status = Execute();
		
		if (status != State.Executing)
		{
			Reset();
			status = State.Sleep;
		}

		return lastStatus;
	}
}