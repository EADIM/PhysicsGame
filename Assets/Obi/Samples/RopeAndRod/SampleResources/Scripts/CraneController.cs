using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class CraneController : MonoBehaviour {

	ObiRopeCursor cursor;
	ObiRope rope;

	ObiSolver ObiSolver1;

	// Use this for initialization
	void Start () {
		cursor = GetComponentInChildren<ObiRopeCursor>();
		rope = cursor.GetComponent<ObiRope>();
		ObiSolver1 = GetComponent<ObiSolver>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.N)){
			if (rope.restLength > 2.5f)
				cursor.ChangeLength(rope.restLength - 2f * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.M)){
			cursor.ChangeLength(rope.restLength + 1f * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.A)){
			transform.Rotate(0,Time.deltaTime*15f,0);
		}

		if (Input.GetKey(KeyCode.D)){
			transform.Rotate(0,-Time.deltaTime*15f,0);
		}
	}

	public void turnOnGravity(){
		ObiSolver1.parameters.gravity = new Vector3(0,-4,0);
		//ObiSolver1.updateParameters();
	}
}
