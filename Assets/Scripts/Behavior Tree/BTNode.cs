using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BTNode{
	public enum Status{
		False = 0,
		True,
		Executing
	}
	public BTNode(){}

	abstract public Status Execute();
}
