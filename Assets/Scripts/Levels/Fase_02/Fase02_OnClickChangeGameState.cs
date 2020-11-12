using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase02_OnClickChangeGameState : MonoBehaviour
{

    public Fase02_References references;

    private Fase02_GameState gameState;

    private void Start() {
        gameState = references.GameState.GetComponent<Fase02_GameState>();
    }

    public void changeState(){

        if(gameState.States[gameState.getExplorationName()]){
            gameState.SwitchState(gameState.getSimulationName());
        }
        else if (gameState.States[gameState.getSimulationName()]){
            gameState.SwitchState(gameState.getExplorationName());
        }
    }
}
