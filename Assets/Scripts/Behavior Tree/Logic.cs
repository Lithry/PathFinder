using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Logic : NodeWithChildrens {

	public Logic() : base() {}
	
	protected abstract bool ExecuteLogic();
	
	override public Status Execute(){
		if (ExecuteLogic())
			return Status.True;
		
		return Status.False;
	}

	override protected bool CanHaveChildren() {
		if (childs.Count >= 2)
			return false;

		return true;
	}
}
