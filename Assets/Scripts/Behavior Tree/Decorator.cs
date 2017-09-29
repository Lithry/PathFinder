using System.Collections;
using System.Collections.Generic;

public class Decorator<T> : NodeWithChildrens<T> {
	public Decorator(T blackboard) : base(blackboard) {}
	
	override protected State Execute() {
		status = childs[0].Play();
		switch(status) {
			case State.True:
				return State.False;
			case State.False:
				return State.True;
		}

		return State.False;
	}

	override protected bool CanHaveChildren(BTNode<T> child) {
		if (!(child is Conditional<T>) && !(child is Logic<T>))
			return false;

		if (childs.Count >= 1)
			return false;
		
		return true;
	}
}
