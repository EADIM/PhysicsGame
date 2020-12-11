using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase03_ButtonPressed : MonoBehaviour
{
    public Fase03_References references;  
    public Fase03_GameState gms;

    void Start() {
        gms = references.GameState.gameObject.GetComponent<Fase03_GameState>();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Player"){
            /*
            * Código para quando colidir
            */
            Debug.Log("Colidiu com " + other.gameObject.name);
            gms.SwitchState(gms.getWinName());
        }
    }
}