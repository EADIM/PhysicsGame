using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase02_DetectColision : MonoBehaviour
{

    public Fase02_References References;

    private Fase02_GameState GameState;

    private Rigidbody RigidBody;

    private void Start() {
        RigidBody = GetComponent<Rigidbody>();
        GameState = References.GameState.GetComponent<Fase02_GameState>();
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "FinalPlatform"){
            Debug.Log("Colidiu com o chao");
            GameState.SwitchState(GameState.getLostName());
        }
    }
}
