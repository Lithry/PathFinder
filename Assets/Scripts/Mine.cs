using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {
	private int resourses;
	// Use this for initialization
	void Start () {
		resourses = 16;
	}
	
	void Update(){}

	public void ResourcesDecrease(int num){
		if (resourses >= num){
			resourses -= num;
		}
	}

	public int GetResoursesNum(){
		return resourses;
	}
}
