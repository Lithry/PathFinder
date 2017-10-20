using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid {
	private Vector2 direction;
	private Vector3 v3Direction;
	private Vector2 dest;
	private Transform trans;
	private Vector2 forward;
	private List<Boid> neighbors = new List<Boid>();
	private bool move;
	private float speed;
	private float rotSpeed = 5.0f;

	public void Start () {
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
			direction = (dest - new Vector2(trans.position.x, trans.position.z)).normalized;
			direction += new Vector2(v3Direction.x, v3Direction.z);
			direction.Normalize();

			forward.Set(trans.forward.x, trans.forward.z);

			Vector2 newDir = Vector2.Lerp(forward, direction, rotSpeed * Time.deltaTime);
			Debug.DrawRay(trans.position, new Vector3(newDir.x, 0, newDir.y), Color.red, 0.2f);
			trans.rotation = Quaternion.LookRotation(new Vector3(newDir.x, 0, newDir.y));
			
			trans.Translate(Vector3.forward * speed * Time.deltaTime);

			/*if (Vector2.Distance(dest, new Vector2(trans.position.x, trans.position.z)) < 2){
				newDir = Vector2.Lerp(forward, direction, 10 * Time.deltaTime);
				Debug.DrawRay(trans.position, new Vector3(newDir.x, 0, newDir.y), Color.red, 0.2f);
				trans.rotation = Quaternion.LookRotation(new Vector3(newDir.x, 0, newDir.y));
			}*/
			//if (Vector2.Distance(dest, new Vector2(trans.position.x, trans.position.z)) < 0.25f)
			//	move = false;
			
		}
	}

	public void Calculate(){
		v3Direction = Vector3.zero;
		Vector3 center = CalculateCenterOfMasse();
		
		Vector3 cohesion = center - trans.position;
		
		float mag = (cohesion / FlockingData.BoidMinDistance).magnitude;
		mag = Mathf.Clamp01(mag);

		cohesion.Normalize();
		Vector3 separation = cohesion * -1;

		v3Direction += CalculateAlignment() + cohesion * mag + separation * (1.0f - mag);

		//v3Direction.Normalize();
	}

	public Vector3 GetPosition(){
		return trans.position;
	}

	public Vector3 GetForward(){
		return trans.forward;
	}

	public void SetNeighbors(Boid neighbor){
		neighbors.Add(neighbor);
	}

	public void ClearNeighbors(){
		neighbors.Clear();
	}

	private Vector3 CalculateAlignment(){
		Vector3 alignament = trans.forward;
		
		if (neighbors.Count != 0){
			//alignament = trans.forward;
			for	(int i = 0; i < neighbors.Count; i++){
				alignament += neighbors[i].GetForward();
			}

			alignament /= (neighbors.Count + 1);
		}

		return alignament.normalized;
	}

	private Vector3 CalculateCenterOfMasse(){
		Vector3 center = trans.position;
		if (neighbors.Count != 0){
			//center = trans.position;
			for	(int i = 0; i < neighbors.Count; i++){
				center += neighbors[i].GetPosition();
			}
			center /= (neighbors.Count + 1);
		}
		return center;
	}
}
