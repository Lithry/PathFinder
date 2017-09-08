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
	private Stack<Node> path = new Stack<Node>();


	void Awake () {

	}

	void Update () {
		
	}
	void Move(){
		/*if ( Input.GetMouseButtonDown (0)){ 
   		RaycastHit hit; 
   		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
   			if ( Physics.Raycast (ray,out hit)) {
				if (!going && Vector3.Distance(transform.position, target) > 1){
						path = PathFinder.instance.FindPhat(transform.position, target);
				}
			}
		}*/
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
}
