﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTo : Action<Blackboard> {
	private Stack<Node> path = new Stack<Node>();
    private Vector3 lastTargetPosition;

    public GoTo(Blackboard blackboard) : base(blackboard) {}

    protected override bool Validate() {
        if (lastTargetPosition != blackboard.GetTargetPosition())
            return false;

        return true;
    }

    protected override void Awake() {
        if (blackboard.GetTargetPosition() != Vector3.zero)
            path = PathFinder.instance.FindPhat(blackboard.GetPlayer().transform.position, blackboard.GetTargetPosition());

        lastTargetPosition = blackboard.GetTargetPosition();
		status = State.Executing;
    }

    protected override State ExecuteAction() {
        if (path != null && path.Count != 0) {
            blackboard.GetPlayer().transform.LookAt(path.Peek().GetPosition());
            blackboard.GetPlayer().transform.position = Vector3.MoveTowards(blackboard.GetPlayer().transform.position, path.Peek().GetPosition(), blackboard.GetSpeed() * Time.deltaTime);

            if (Vector3.Distance(path.Peek().GetPosition(), blackboard.GetPlayer().transform.position) < 0.10f) {
                if (path.Count <= 1 && Vector3.Distance(path.Peek().GetPosition(), blackboard.GetPlayer().transform.position) < 0.10f) {
                    Debug.Log("Goin To - True");
                    return State.True;
                }
                else
                    path.Pop();
            }
        }
        else {
            blackboard.ResetTargetPosition();
            blackboard.ResetTarget();
            Debug.Log("Goin To - False");
            return State.False;
        }
        Debug.Log("Goin To - Executing");
        return State.Executing;
    }

    protected override void Reset() {
        path = null;
		status = State.Sleep;
    }
}
