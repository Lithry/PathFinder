using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decorator : NodeWithChildrens {

	public Decorator() : base() {}
	
	protected abstract bool ExecuteDecorator();
	
	override public Status Execute(){
		if (ExecuteDecorator())
			return Status.True;
		
		return Status.False;
	}

	override protected bool CanHaveChildren() {
		if (childs.Count >= 1)
			return false;
		
		return true;
	}
}
