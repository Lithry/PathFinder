using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State {
	private GoToDig goToDig;
	public Idle(Transform obj, FSM fsm) : base(obj, fsm) {}

	override public void Play(){
	transform.Rotate(Vector3.up * 100 * Time.deltaTime, Space.World);
	if ( Input.GetMouseButtonDown (0)){ 
   		RaycastHit hit; 
   		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
   		if ( Physics.Raycast (ray,out hit)) {
			if (hit.transform.tag == "Mina"){
				fsm.ReceiveEvent((int)PlayerController.Events.GoMine);
				}
			}
		}
	}
}
