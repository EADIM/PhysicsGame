using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase03_DetectColision : MonoBehaviour
{

    public Fase03_References References;

    private Fase03_GameState GameState;

    private Rigidbody RigidBody;

    private void Start() {
        RigidBody = GetComponent<Rigidbody>();
        GameState = References.GameState.GetComponent<Fase03_GameState>();
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "FinalPlatform"){
            Debug.Log("Colidiu com o chao");
            GameState.SwitchState(GameState.getLostName());
        }
    }
}
