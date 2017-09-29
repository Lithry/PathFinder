using System.Collections;
using System.Collections.Generic;

public abstract class Action<T> : BTNode<T> {

	public Action (T blackboard) : base(blackboard) {}

	protected abstract State ExecuteAction();
	
	override protected State Execute() {
		return ExecuteAction();
	}
}
