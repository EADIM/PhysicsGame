using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class RopeLengthController : MonoBehaviour
{

	public float speed = 1;
	ObiRopeCursor cursor;
	ObiRope rope;
	public float Isize;
	public ObiRope initial;

	private Vector3 pos;
	private Quaternion rot;
	public Fase03_References references;
	private GameObject objRope;

	void Start()
	{
		cursor = (ObiRopeCursor)GetComponentInChildren(typeof(ObiRopeCursor));
		rope = (ObiRope)cursor.GetComponent(typeof(ObiRope));
		Isize = rope.restLength;
		pos = rope.transform.position;
		rot = rope.transform.rotation;
	}

	public bool deleteRope(){
		if(rope.restLength > 80.0f){
			cursor.ChangeLength(rope.restLength - speed * Time.deltaTime);
			return false;
		}
		return true;
	}

	public void restoreRope(){
		if (Isize != rope.restLength && transform.childCount == 1){
			Destroy(Utils.GetChildWithName(transform.gameObject, "Obi Rope"));
			
			objRope = Instantiate(initial, pos, rot, transform).transform.gameObject;
			objRope.transform.name = "Obi Rope";
			rope = objRope.GetComponent<ObiRope>();
			cursor = objRope.GetComponent<ObiRopeCursor>();
		}	
	}
}