using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDeposite : Action<Blackboard>{
    private Stack<Node> path = new Stack<Node>();
    private Vector3 lastTargetPosition;

    public GoDeposite(Blackboard blackboard) : base(blackboard) {}

    protected override bool Validate() {
        if (lastTargetPosition != blackboard.GetTargetPosition())
            return false;

        return true;
    }

    protected override void Awake() {
        if (blackboard.GetHome() != null) {
            Vector3 pos = new Vector3();
            pos.Set(blackboard.GetHome().transform.position.x, 0, blackboard.GetHome().transform.position.z);
            path = PathFinder.instance.FindPhat(blackboard.GetPlayer().transform.position, pos);
        }

        lastTargetPosition = blackboard.GetTargetPosition();
        status = State.Executing;
    }

    protected override State ExecuteAction() {
        if (path != null && path.Count != 0) {
            blackboard.GetPlayer().transform.LookAt(path.Peek().GetPosition());
            blackboard.GetPlayer().transform.position = Vector3.MoveTowards(blackboard.GetPlayer().transform.position, path.Peek().GetPosition(), blackboard.GetSpeed() * Time.deltaTime);

            if (Vector3.Distance(path.Peek().GetPosition(), blackboard.GetPlayer().transform.position) < 0.10f) {
                if (path.Count <= 1 && Vector3.Distance(path.Peek().GetPosition(), blackboard.GetPlayer().transform.position) < 0.10f) {
                    Debug.Log("Go Deposite - True");
                    return State.True;
                }
                else
                    path.Pop();
            }
        }
        else {
            blackboard.ResetTargetPosition();
            blackboard.ResetTarget();
            Debug.Log("Go Deposite - False");
            return State.False;
        }
        Debug.Log("Go Deposite - Executing");
        return State.Executing;
    }

    protected override void Reset() {
        path = null;
        status = State.Sleep;
    }
}