using System.Collections;
using System.Collections.Generic;

public abstract class Logic<T> : NodeWithChildrens<T> {

	public Logic(T blackboard) : base(blackboard) {}

	override protected void Awake(){}
	
	abstract protected bool ExecuteLogic();
	
	override protected State Execute(){
		if (ExecuteLogic())
			return State.True;
		
		return State.False;
	}

	override protected bool CanHaveChildren(BTNode<T> child) {
		if (childs.Count >= 2)
			return false;

		return true;
	}
}
