using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase02_ButtonPressed : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Ball"){
            /*
            * Código para quando colidir
            */
            Debug.Log("Colidiu com " + other.gameObject.name);
        }
    }
}