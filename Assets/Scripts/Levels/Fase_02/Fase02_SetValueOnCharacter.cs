using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase02_SetValueOnCharacter : MonoBehaviour
{
    public Fase02_References references;
    public TMPro.TMP_InputField inputField;

    public void setValue(int attribute){
        GameObject player = references.Player.gameObject;
        Fase02_PlayerController pcont = player.GetComponent<Fase02_PlayerController>();

        GameObject box = references.Box.gameObject;
        Fase02_PlayerController boxCont = box.GetComponent<Fase02_PlayerController>();
        
        if (attribute == 0)
            pcont.setAcceleration(inputField.text);
        else if(attribute == 1)
            boxCont.setBoxMass(inputField.text);
        else if(attribute == 2)
            pcont.setGravity(inputField.text);
        else if(attribute == 3)
            pcont.setBallMass(inputField.text);
    }

}
