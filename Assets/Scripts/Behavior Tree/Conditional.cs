using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Conditional : BTNode {

	public Conditional() : base() {}

	protected abstract bool ExecuteCondition();

	override public Status Execute(){
		if (ExecuteCondition())
			return Status.True;
		
		return Status.False;
	}
}
