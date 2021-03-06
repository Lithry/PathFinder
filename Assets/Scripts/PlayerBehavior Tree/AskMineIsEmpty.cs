﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskMineIsEmpty : Conditional<Blackboard> {

    public AskMineIsEmpty(Blackboard blackboard) : base(blackboard) {}

    protected override void Awake() {
        status = State.Executing;
    }

    protected override bool ExecuteCondition() {
        
        if (blackboard.GetTarget().GetComponent<Mine>().GetResoursesNum() <= 0) {
            Debug.Log("Asking if is Empty - True");
            return true;
        }

        Debug.Log("Asking if is Empty - False");
        return false;
    }

    protected override void Reset() {
        status = State.Sleep;
    }
}
