using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingManager : MonoBehaviour {
	static public FlockingManager instance;
	private List<Boid> boids = new List<Boid>();
	private Boid boidA;
	private Boid boidB;
	public float boidsViewRange;
	public GameObject players;
	public int numOfPlayers;

	void Awake () {
		instance = this;
		for (int i = 0; i < numOfPlayers; i++){
			Instantiate(players, new Vector3(Random.Range(-20, 21), 0, Random.Range(-20, 21)), Quaternion.Euler(new Vector3(0, Random.Range(0, 361), 0)));
		}
	}

	void Update () {

		for(int i = 0; i < boids.Count; i++){
			boidA = boids[i];
			for(int j = i + 1; j < boids.Count; j++){
				boidB = boids[j];
					if (Vector3.Distance(boidA.GetPosition(), boidB.GetPosition()) < boidsViewRange){
						boidA.SetNeighbors(boidB);
						boidB.SetNeighbors(boidA);
					}
			}

			boidA.Calculate();
			boidA.ClearNeighbors();
		}
	}

	public void SetBoids(Boid boid){
		boids.Add(boid);
	}
}
