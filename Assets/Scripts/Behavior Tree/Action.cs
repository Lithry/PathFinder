using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : BTNode {

	public Action() : base() {}

	protected abstract Status ExecuteAction();
	override public Status Execute(){
		return ExecuteAction();
	}
}
