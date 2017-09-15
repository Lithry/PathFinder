using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed;
	private int bag = 0;
	public bool search;

	private PlayerAIBuilder AIBuilder = new PlayerAIBuilder();
	private Blackboard blackboard = new Blackboard();
	private BTNode<Blackboard> AI;

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
		blackboard.SetPlayer(this);
		AI = AIBuilder.BuildAI(blackboard);
	}

	void Update () {
		Move();
		AI.Play();
	}

	void Move(){
		if ( Input.GetMouseButtonDown (0)){ 
   		RaycastHit hit; 
   		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
   			if ( Physics.Raycast (ray,out hit)) {
				blackboard.SetTargetPosition(new Vector3(hit.transform.position.x, 0, hit.transform.position.z));
				blackboard.SetTarget(hit.transform.gameObject);
			}
		}
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
