using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskIsAMine : Conditional<Blackboard>{
    public AskIsAMine(Blackboard blackboard) : base(blackboard){}

    protected override void Awake()
    {
        status = State.Executing;
    }

    protected override bool ExecuteCondition()
    {
        if (blackboard.GetTarget() != null && blackboard.GetTarget().tag == "Mine")
			return true;

		return false;
    }

    protected override void Reset()
    {
        status = State.Sleep;
    }
}
