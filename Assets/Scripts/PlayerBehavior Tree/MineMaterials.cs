using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineMaterials : Action<Blackboard>{
    private Mine target;
    private float timer;
    private Vector3 lastTargetPosition;

    public MineMaterials(Blackboard blackboard) : base(blackboard) {}

    protected override bool Validate() {
        if (lastTargetPosition != blackboard.GetTargetPosition())
            return false;

        return true;
    }

    protected override void Awake() {
        target = blackboard.GetTarget().GetComponent<Mine>();
        timer = 0;
        lastTargetPosition = blackboard.GetTargetPosition();
    }


    protected override State ExecuteAction() {
        Debug.Log("MiningMaterials");
        timer += Time.deltaTime;
        if (!blackboard.GetPlayer().BagIsFull() && timer > 4) {
            switch (target.GetResoursesNum()) {
                case 5:
                    blackboard.GetPlayer().AddResoursesToBag(5);
                    target.ResourcesDecrease(5);

                    Debug.Log("MiningMaterials - True");
                    return State.True;
                case 4:
                    blackboard.GetPlayer().AddResoursesToBag(4);
                    target.ResourcesDecrease(4);

                    return State.True;
                case 3:
                    blackboard.GetPlayer().AddResoursesToBag(3);
                    target.ResourcesDecrease(3);

                    Debug.Log("MiningMaterials - True");
                    return State.True;
                case 2:
                    blackboard.GetPlayer().AddResoursesToBag(2);
                    target.ResourcesDecrease(2);

                    Debug.Log("MiningMaterials - True");
                    return State.True;
                case 1:
                    blackboard.GetPlayer().AddResoursesToBag(1);
                    target.ResourcesDecrease(1);

                    Debug.Log("MiningMaterials - True");
                    return State.True;
                default:
                    blackboard.GetPlayer().AddResoursesToBag(5);
                    target.ResourcesDecrease(5);
                    timer = 0;
                    if (blackboard.GetPlayer().BagIsFull()){
                        Debug.Log("MiningMaterials - True");
                        return State.True;
                    }

                    Debug.Log("MiningMaterials - Executing");
                    return State.Executing;
            }
        }
        else {
            if (timer < 4){
                Debug.Log("MiningMaterials - Executing");
                return State.Executing;
            }

            Debug.Log("MiningMaterials - True");
            return State.True;
        }
    }

    protected override void Reset() {
        target = null;
    }
}
