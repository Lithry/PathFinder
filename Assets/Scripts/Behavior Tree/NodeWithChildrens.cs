using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeWithChildrens : BTNode {
	protected List<BTNode> childs = new List<BTNode>();
	public NodeWithChildrens() : base() {}
	
	override public Status Execute() {
		return Status.True;
	}

	public bool AddChildren(BTNode child) {
		if (CanHaveChildren()) {
			childs.Add(child);	
			return true;
		}		
		return false;
	}

	virtual protected bool CanHaveChildren() {
		return true;
	}
}
