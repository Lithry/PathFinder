using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : NodeWithChildrens {

	public Selector() : base() {}

	override public Status Execute() {
		return Status.True;
	}
}
