using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTo : Action<Blackboard> {
	private PathFinder pathFinder = new PathFinder();
	private Stack<Node> path = new Stack<Node>();

    public GoTo(Blackboard blackboard) : base(blackboard)
    {
    }

    protected override void Awake() {
        path = pathFinder.FindPhat(blackboard.GetPlayer().transform.position, blackboard.GetTargetPosition());
		status = State.Executing;
    }

    protected override State ExecuteAction() {
		if (path != null){
			blackboard.GetPlayer().transform.LookAt(path.Peek().GetPosition());
			blackboard.GetPlayer().transform.position = Vector3.MoveTowards(blackboard.GetPlayer().transform.position, path.Peek().GetPosition(), blackboard.GetSpeed() * Time.deltaTime);

			if (Vector3.Distance(path.Peek().GetPosition(), blackboard.GetPlayer().transform.position) < 0.10f){
				path.Pop();
				if (path.Count < 1){
					if (Vector3.Distance(blackboard.GetPlayer().transform.position, blackboard.GetTargetPosition()) < 0.10f)
						return State.True;
				}
			}

		}
		else
			return State.False;

		return State.Executing;
    }

    protected override void Reset() {
        path.Clear();
		status = State.Sleep;
    }
}
