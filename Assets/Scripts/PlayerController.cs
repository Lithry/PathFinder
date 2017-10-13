using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject home;
    public float speed;
	private int bag = 0;
	public bool search;
	private Boid boid = new Boid();

	

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
//	private Stack<Node> path = new Stack<Node>();


	void Awake () {
		boid.SetParentTransform(transform);
		boid.SetSpeed(speed);
	}

	void Update () {
		Move();
		boid.Move();
	}

	void Move(){
		if ( Input.GetMouseButtonDown (0)){ 
   		RaycastHit hit; 
   		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
   			if ( Physics.Raycast (ray,out hit)) {
				boid.PassDirection(new Vector2(hit.point.x, hit.point.z));
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

    public void ResetBag(){
        bag = 0;
    }
}
