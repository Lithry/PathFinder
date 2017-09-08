using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposite : State {
	private Home warehouse;
	private PlayerController player;
	private float timer = Time.time;
	public Deposite(PlayerController player, Transform obj, FSM fsm) : base(obj, fsm) {
		this.player = player;
	}

	override public void Play(){
		if (Vector3.Distance(transform.position, warehouse.transform.position) > 1)
			fsm.ReceiveEvent((int)PlayerController.Events.Unknown);

		if ((Time.time - timer) > 2){
			switch(player.getBagNum()){
				case 5:
					warehouse.DepositeOnWarehouse(5);
					player.DepositeResoursesFromBag(5);
					fsm.ReceiveEvent((int)PlayerController.Events.Empty);
					break;
				case 4:
					warehouse.DepositeOnWarehouse(4);
					player.DepositeResoursesFromBag(4);
					fsm.ReceiveEvent((int)PlayerController.Events.Empty);
					break;
				case 3:
					warehouse.DepositeOnWarehouse(3);
					player.DepositeResoursesFromBag(3);
					fsm.ReceiveEvent((int)PlayerController.Events.Empty);
					break;
				case 2:
					warehouse.DepositeOnWarehouse(2);
					player.DepositeResoursesFromBag(2);
					fsm.ReceiveEvent((int)PlayerController.Events.Empty);
					break;
				case 1:
					warehouse.DepositeOnWarehouse(1);
					player.DepositeResoursesFromBag(1);
					fsm.ReceiveEvent((int)PlayerController.Events.Empty);
					break;
				default:
					warehouse.DepositeOnWarehouse(5);
					player.DepositeResoursesFromBag(5);
					break;
			}

			timer = Time.time;

			if (player.BagIsEmpty())
				fsm.ReceiveEvent((int)PlayerController.Events.Empty);
		}
	}

	public void SetWarehouse(Home warehouse){
		this.warehouse = warehouse;
	}
}
