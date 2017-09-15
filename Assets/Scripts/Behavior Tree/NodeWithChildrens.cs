using System.Collections;
using System.Collections.Generic;

public class NodeWithChildrens<T> : BTNode<T> {
	protected List<BTNode<T>> childs = new List<BTNode<T>>();
	public NodeWithChildrens(T blackboard) : base(blackboard) {}
	
	override protected void Awake(){}

	override protected State Execute() {
		return State.True;
	}

    override protected void Reset(){}
	
	public bool AddChildren(BTNode<T> child) {
		if (CanHaveChildren(child)) {
			childs.Add(child);	
			return true;
		}		
		return false;
	}

	virtual protected bool CanHaveChildren(BTNode<T> child) {
		return true;
	}

}
