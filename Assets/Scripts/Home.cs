using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {
	private int warehouse;
	// Use this for initialization
	void Start () {
		warehouse = 0;
	}
	
	void Update(){}

	public void DepositeOnWarehouse(int num){
		warehouse += num;
	}

	public int GetWarehouseNum(){
		return warehouse;
	}
}
