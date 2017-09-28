using System.Collections;
using System.Collections.Generic;

public class Selector<T> : NodeWithChildrens<T> {
	private int childIndex;
	public Selector(T blackboard) : base(blackboard) {}

	override protected void Awake(){}

	override protected State Execute() {
			while(childIndex < childs.Count){
			status = childs[childIndex].Play();

			switch(status){
				case State.Executing:
				return status;
				case State.False:
				childIndex++;
				return status;
				case State.True:
				childIndex = 0;
				break;
			}
		}

        if (childIndex >= childs.Count)
            childIndex = 0;

        return status;
	}
}
