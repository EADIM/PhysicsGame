using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase02_ButtonPressed : MonoBehaviour
{
    public Fase02_References references;  
    public Fase02_GameState gms;

    void Start() {
        gms = references.GameState.gameObject.GetComponent<Fase02_GameState>();
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