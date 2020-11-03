using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase02_DetectColision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {

        Debug.Log("Colidiu:  " + GetComponent<Renderer>().transform.localPosition);
    }
}
