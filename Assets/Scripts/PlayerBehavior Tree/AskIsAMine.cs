using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskIsAMine : Conditional<Blackboard> {

    public AskIsAMine(Blackboard blackboard) : base(blackboard) {}

    protected override void Awake() {
        status = State.Executing;
    }

    protected override bool ExecuteCondition(){
        if (blackboard.GetTarget() != null && blackboard.GetTarget().tag == "Mina") {
            Debug.Log("Asking if is Mine - True");
            return true;
        }

        Debug.Log("Asking if is Mine - False");
        return false;
    }

    protected override void Reset(){
        status = State.Sleep;
    }
}
