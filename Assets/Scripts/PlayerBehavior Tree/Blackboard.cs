using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard {
	private Vector3 targetPosition;
    private GameObject target;
    private GameObject home;
    private PlayerController player;
    private float speed;

    public Vector3 GetTargetPosition() {
         return targetPosition; 
    }
    
    public void SetTargetPosition(Vector3 value) {
        targetPosition = value;
    }

    public void ResetTargetPosition() {
        targetPosition = Vector3.zero;
    }

    public GameObject GetTarget() {
         return target; 
    }

    public void SetTarget(GameObject value) {
        target = value;
    }

    public void ResetTarget() {
        target = null;
    }

    public GameObject GetHome() {
        return home;
    }

    public void SetHome(GameObject value) {
        home = value;
    }

    public PlayerController GetPlayer() {
        return player;
    }

    public void SetPlayer(PlayerController value) {
        player = value;
    }

    public float GetSpeed() {
        return speed;
    }
    
    public void SetSpeed(float value) {
        speed = value;
    }
}
