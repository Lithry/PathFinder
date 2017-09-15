using System.Collections;
using System.Collections.Generic;

public abstract class Conditional<T> : BTNode<T> {

	public Conditional(T blackboard) : base(blackboard) {}

	

	protected abstract bool ExecuteCondition();

	override protected State Execute(){
		if (ExecuteCondition())
			return State.True;
		
		return State.False;
	}
}
