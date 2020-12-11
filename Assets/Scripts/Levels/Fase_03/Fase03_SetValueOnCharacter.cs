using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase03_SetValueOnCharacter : MonoBehaviour
{
    public Fase03_References references;
    public TMPro.TMP_InputField inputField;

    public void setValue(int attribute){
        /*GameObject player = references.Player.gameObject;
        Fase03_PlayerController pcont = player.GetComponent<Fase03_PlayerController>();*/

        GameObject box = references.Box.gameObject;
        Fase03_BoxController boxCont = box.GetComponent<Fase03_BoxController>();

        /*GameObject ball = references.Ball.gameObject;
        Fase03_PlayerController ballCont = ball.GetComponent<Fase03_PlayerController>();*/
        
        if (attribute == 0){
            boxCont.setMotorRounds(inputField.text);
        }
            
        /*else if(attribute == 1)
            boxCont.setBoxMass(inputField.text);
        else if(attribute == 2)
            pcont.setGravity(inputField.text);
        else if(attribute == 3)
            ballCont.setBallMass();*/
    }

}
