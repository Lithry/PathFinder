using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour {
	int[,] stateMatrice;
	private State[] states;
	private State state;
	int currentState = 0;

	public void Init(int statesCount, int eventNum, State[] statesList){
		stateMatrice = new int[statesCount,eventNum];
		for(int i = 0; i < statesCount - 1; i++){
			for(int j = 0; j < eventNum - 1; j++){
				stateMatrice[i,j] = -1;
			}
		}
		states = statesList;
		state = states[0];
		currentState = 0;
	}

	public void SetRelation(int homeState, int eventGoing, int destinationState){
		stateMatrice[homeState, eventGoing] = destinationState;
	}

	public void ReceiveEvent(int eventGoing){
		int newState = stateMatrice[currentState, eventGoing];
		if (newState != -1)
		{
			currentState = newState;
			state = states[currentState];
		}
	}

	public void GetState(){

	}

	public void PlayState(){
		state.Play();
	}
}
