using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class RopeLengthController : MonoBehaviour
{

	public float speed = 1;
	ObiRopeCursor cursor;
	ObiRope rope;

	void Start()
	{

		cursor = (ObiRopeCursor)GetComponentInChildren(typeof(ObiRopeCursor));
		rope = (ObiRope)cursor.GetComponent(typeof(ObiRope));
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.N))
			cursor.ChangeLength(rope.restLength - speed * Time.deltaTime);

		if (Input.GetKey(KeyCode.M))
			cursor.ChangeLength(rope.restLength + speed * Time.deltaTime);
	}
}

