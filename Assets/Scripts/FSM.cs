using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour {
	int[,] stateMatrice;
	private State[] states;
	private State state;

	public void Init(int statesCount, int eventNum){
		stateMatrice = new int[statesCount,eventNum];
		for(int i = 0; i < statesCount - 1; i++){
			for(int j = 0; j < eventNum; j++){
				stateMatrice[i,j] = -1;
			}
		}
		states = new State[statesCount];
	}

	public void SetRelation(int homeState, int even, int destinationState){

	}

	public void SetEvent(){

	}

	public void GetState(){

	}

	public void PlayState(){
		state.Play();
	}
}
