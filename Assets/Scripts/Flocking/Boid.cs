using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid {
	private Vector2 direcction;
	private Vector2 dest;
	private Transform trans;
	private Vector2 forward;
	private List<Boid> neighbors = new List<Boid>();
	private bool move;
	private float speed;

	void Start () {
		FlockingManager.instance.SetBoids(this);
	}

	public void SetParentTransform(Transform transform){
		trans = transform;
	}

	public void SetSpeed(float speed){
		this.speed = speed;
	}

	public void PassDirection(Vector2 posOfDest){
		dest = posOfDest;
		move = true;
	}

	public void Move(){
		if (move){
			direcction = dest - new Vector2(trans.position.x, trans.position.z);
			forward.Set(trans.forward.x, trans.forward.z);

			Vector2 newDir = Vector2.Lerp(forward, direcction, 0.015f);
			Debug.DrawRay(trans.position, new Vector3(newDir.x, 0, newDir.y), Color.red, 0.2f);
			trans.rotation = Quaternion.LookRotation(new Vector3(newDir.x, 0, newDir.y));
			
			trans.Translate(Vector3.forward * speed * Time.deltaTime);

			if (Vector2.Distance(dest, new Vector2(trans.position.x, trans.position.z)) < 2){
				newDir = Vector2.Lerp(forward, direcction, 0.3f);
				Debug.DrawRay(trans.position, new Vector3(newDir.x, 0, newDir.y), Color.red, 0.2f);
				trans.rotation = Quaternion.LookRotation(new Vector3(newDir.x, 0, newDir.y));
			}
			if (Vector2.Distance(dest, new Vector2(trans.position.x, trans.position.z)) < 0.25f)
				move = false;
			
		}
	}

	public void Calculate(){

	}

	public Vector3 GetPosition(){
		return trans.position;
	}

	public void SetNeighbors(Boid neighbor){
		neighbors.Add(neighbor);
	}

	public void ClearNeighbors(){
		neighbors.Clear();
	}

}
