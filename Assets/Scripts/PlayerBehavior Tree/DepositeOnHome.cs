using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositeOnHome : Action<Blackboard>{
    private Home target;
    private Vector3 lastTargetPosition;
    private float timer;

    public DepositeOnHome(Blackboard blackboard) : base(blackboard) {}

    protected override bool Validate() {
        if (lastTargetPosition != blackboard.GetTargetPosition())
            return false;

        return true;
    }

    protected override void Awake() {
        lastTargetPosition = blackboard.GetTargetPosition();
        target = blackboard.GetHome().GetComponent<Home>();
        timer = 0;
    }

    protected override State ExecuteAction() {
        timer += Time.deltaTime;

        if (timer > 3) {
            target.DepositeOnWarehouse(blackboard.GetPlayer().getBagNum());
            blackboard.GetPlayer().ResetBag();
            Debug.Log("DepositeOnHome - True");
            return State.True;
        }

        Debug.Log("DepositeOnHome - Executing");
        return State.Executing;
    }

    protected override void Reset() {
        lastTargetPosition = Vector3.zero;
        status = State.Sleep;
    }
}