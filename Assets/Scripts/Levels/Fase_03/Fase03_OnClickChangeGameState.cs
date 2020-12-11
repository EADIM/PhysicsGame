using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase03_OnClickChangeGameState : MonoBehaviour
{

    public Fase03_References references;

    private Fase03_GameState gameState;

    private void Start() {
        gameState = references.GameState.GetComponent<Fase03_GameState>();
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
