using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase02_GetValueFromPlayer : MonoBehaviour
{
    public Fase01_References references;

    private Fase02_PlayerController sim;
    public int attribute = 0;

    private void Start() {
        sim = references.Player.GetComponent<Fase02_PlayerController>();
    }

    private void Update() {
        setText(getAttribute());
    }

    private float getAttribute(){
        float value = 0.0f;
        if (attribute == 0){
            value = sim.Acceleration;
        }
        else if (attribute == 1){
            value = sim.Box_mass;
        }
        else if (attribute == 2){
            value = Mathf.Abs(sim.Gravity);
        }
        else if (attribute == 3){
            value = sim.Ball_mass;
        }

        return value;
    }

    private void setText(float value){
        this.GetComponent<TMPro.TMP_Text>().text = value.ToString();
    }
}
