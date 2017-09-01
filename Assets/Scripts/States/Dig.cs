using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dig : State {
	private Mine mine;
	private float timer = Time.time;
	private PlayerController player;
	public Dig(PlayerController player, Transform obj, FSM fsm) : base(obj, fsm) {
		this.player = player;
	}
	// Use this for initialization

	override public void Play(){
		if (Vector3.Distance(transform.position, mine.transform.position) > 1)
			fsm.ReceiveEvent((int)PlayerController.Events.Unknown);

		if ((Time.time - timer) > 2){
			switch(mine.GetResoursesNum()){
				case 5:
					mine.ResourcesDecrease(5);
					player.AddResoursesToBag(5);
					fsm.ReceiveEvent((int)PlayerController.Events.MineEmpty);
					break;
				case 4:
					mine.ResourcesDecrease(4);
					player.AddResoursesToBag(4);
					fsm.ReceiveEvent((int)PlayerController.Events.MineEmpty);
					break;
				case 3:
					mine.ResourcesDecrease(3);
					player.AddResoursesToBag(3);
					fsm.ReceiveEvent((int)PlayerController.Events.MineEmpty);
					break;
				case 2:
					mine.ResourcesDecrease(2);
					player.AddResoursesToBag(2);
					fsm.ReceiveEvent((int)PlayerController.Events.MineEmpty);
					break;
				case 1:
					mine.ResourcesDecrease(1);
					player.AddResoursesToBag(1);
					fsm.ReceiveEvent((int)PlayerController.Events.MineEmpty);
					break;
				default:
					mine.ResourcesDecrease(5);
					player.AddResoursesToBag(5);
					break;
			}

			timer = Time.time;

			if (player.BagIsFull())
				fsm.ReceiveEvent((int)PlayerController.Events.Full);
		}
	}

	public void SetMine(Mine mine){
		this.mine = mine;
	}
}
