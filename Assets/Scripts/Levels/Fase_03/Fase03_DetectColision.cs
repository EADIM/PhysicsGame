using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase03_DetectColision : MonoBehaviour
{

    public Fase03_References references;

    private Fase03_GameState GameState;

    private Rigidbody RigidBody;

    private void Start() {
        
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Box"){
            references.Box.GetComponent<Fase03_BoxController>().shouldGoDown = false;
        }
    }
}
