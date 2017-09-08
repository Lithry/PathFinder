using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed;
	private int bag = 0;
	public bool search;
	public GameObject cuartel;
	public GameObject mina;
	private FSM stateMachin;
	private bool onTrigger;
	private string triggerWith;

	public enum States{
		Idle = 0,
		GoToDig,
		Dig,
		GoToDeposite,
		Deposite,
		TotalStatesCount
	}

	public enum Events{
		GoMine = 0,
		Arrived,
		MineEmpty,
		Full,
		Empty,
		Unknown,
		TotalEventsCount
	}

	private State[] states;

	void Awake () {
		search = false;
		//speed = 4;
		stateMachin = new FSM();
		
		Transform trans = transform;
		states = new State[] {
		new Idle(trans, stateMachin),
		new GoToDig(trans, stateMachin),
		new Dig(this, trans, stateMachin),
		new GoToDeposite(trans, stateMachin),
		new Deposite(this, trans, stateMachin)
		};

		((GoToDig)states[(int)States.GoToDig]).SetTarget(mina.GetComponent<Mine>());
		((GoToDig)states[(int)States.GoToDig]).SetSpeed(speed);
		((Dig)states[(int)States.Dig]).SetMine(mina.GetComponent<Mine>());
		((GoToDeposite)states[(int)States.GoToDeposite]).SetTarget(cuartel.transform.position);
		((GoToDeposite)states[(int)States.GoToDeposite]).SetSpeed(speed);
		((Deposite)states[(int)States.Deposite]).SetWarehouse(cuartel.GetComponent<Home>());

		stateMachin.Init((int)States.TotalStatesCount, (int)Events.TotalEventsCount, states);
		stateMachin.SetRelation((int)States.Idle, (int)Events.GoMine, (int)States.GoToDig);
		stateMachin.SetRelation((int)States.GoToDig, (int)Events.Arrived, (int)States.Dig);
		stateMachin.SetRelation((int)States.GoToDig, (int)Events.MineEmpty, (int)States.Idle);
		stateMachin.SetRelation((int)States.GoToDig, (int)Events.Unknown, (int)States.Idle);
		stateMachin.SetRelation((int)States.Dig, (int)Events.MineEmpty, (int)States.GoToDeposite);
		stateMachin.SetRelation((int)States.Dig, (int)Events.Full, (int)States.GoToDeposite);
		stateMachin.SetRelation((int)States.Dig, (int)Events.Unknown, (int)States.Idle);
		stateMachin.SetRelation((int)States.GoToDeposite, (int)Events.Arrived, (int)States.Deposite);
		stateMachin.SetRelation((int)States.GoToDeposite, (int)Events.Unknown, (int)States.Idle);
		stateMachin.SetRelation((int)States.Deposite, (int)Events.MineEmpty, (int)States.Idle);
		stateMachin.SetRelation((int)States.Deposite, (int)Events.Empty, (int)States.GoToDig);
		stateMachin.SetRelation((int)States.Deposite, (int)Events.Unknown, (int)States.Idle);
	}
	
	void Update () {
		stateMachin.PlayState();
		Debug.Log("Bag: " + bag.ToString());
	}

	public void AddResoursesToBag(int num){
		bag += num;
	}

	public void DepositeResoursesFromBag(int num){
		bag -= num;
	}
	
	public bool BagIsEmpty(){
		if (bag >= 1)
			return false;
		else
			return true;
	}

	public bool BagIsFull(){
		if (bag >= 10)
			return true;
		else
			return false;
	}

	public int getBagNum(){
		return bag;
	}

	public string GetCollition(){
		if (onTrigger)
			return triggerWith;
		else
			return null;
	}

	void OnTriggerStay(Collider other) {
        onTrigger = true;
		triggerWith = other.transform.tag;
    }
	
	void OnTriggerExit(Collider other) {
        onTrigger = false;
    }
}
