using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : NodeWithChildrens {

	public Sequence() : base() {}

	override public Status Execute() {
		return Status.True;
	}
}
