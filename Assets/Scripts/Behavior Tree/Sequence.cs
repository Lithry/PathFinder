using System.Collections;
using System.Collections.Generic;

public class Sequence<T> : NodeWithChildrens<T> {
	private int childIndex;
	public Sequence(T blackboard) : base(blackboard) {}

	override protected void Awake(){}

	override protected State Execute() {
		while(childIndex < childs.Count){
			status = childs[childIndex].Play();

			switch(status){
				case State.Executing:
				return status;
				case State.False:
				childIndex = 0;
				return status;
				case State.True:
				childIndex++;
				break;
			}
		}
		return status;
	}
}
