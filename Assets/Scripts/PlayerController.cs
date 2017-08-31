using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Stack<Node> path = new Stack<Node>();
	public float speed;
	public Vector3 moveTo;
	private int bag = 0;
	public bool search;
	public GameObject cuartel;
	public GameObject mina;
	private FSM stateMachin;

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
		TotalEventsCount
	}

	private State[] states;

	void Start () {
		search = false;
		speed = 4;
		stateMachin = new FSM();
		
		states = new State[] {
		new Idle(transform, stateMachin),
		new GoToDig(transform, stateMachin),
		new Dig(transform, stateMachin),
		new GoToDeposite(transform, stateMachin),
		new Deposite(transform, stateMachin)
		};
		
		((GoToDig)states[(int)States.GoToDig]).SetTarget(mina.transform.position);
		((GoToDig)states[(int)States.GoToDig]).SetSpeed(speed);
		((GoToDeposite)states[(int)States.GoToDeposite]).SetTarget(cuartel.transform.position);

		stateMachin.Init((int)States.TotalStatesCount, (int)Events.TotalEventsCount, states);
		stateMachin.SetRelation((int)States.Idle, (int)Events.GoMine, (int)States.GoToDig);
		stateMachin.SetRelation((int)States.GoToDig, (int)Events.Arrived, (int)States.Dig);
		stateMachin.SetRelation((int)States.Dig, (int)Events.MineEmpty, (int)States.GoToDeposite);
		stateMachin.SetRelation((int)States.Dig, (int)Events.Full, (int)States.GoToDeposite);
		stateMachin.SetRelation((int)States.GoToDeposite, (int)Events.Arrived, (int)States.Deposite);
		stateMachin.SetRelation((int)States.Deposite, (int)Events.MineEmpty, (int)States.Idle);
		stateMachin.SetRelation((int)States.Deposite, (int)Events.Empty, (int)States.GoToDig);
	}
	
	// Update is called once per frame
	void Update () {
		//Move();
		stateMachin.PlayState();
	}

	void Move(){
		if (search){
			search = false;
			path.Clear();
			path = PathFinder.instance.FindPhat(transform.position, moveTo);
		}

		if (path != null && path.Count > 0){
			transform.LookAt(path.Peek().GetPosition());
			transform.position = Vector3.MoveTowards(transform.position, path.Peek().GetPosition(), speed * Time.deltaTime);

			if (Vector3.Distance(path.Peek().GetPosition(), transform.position) < 0.10f){
				path.Pop();
			}
		}
	}

	public bool isEmpty(){
		if (bag > 0)
			return false;
		else
			return true;
	}
}
