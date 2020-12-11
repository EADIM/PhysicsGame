using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase03_GetValueFromPlayer : MonoBehaviour
{
    public Fase03_References references;

    private Fase03_BoxController sim;
    public int attribute = 0;

    private Fase03_PlayerController Ball;

    private void Start() {
        sim = references.Box.GetComponent<Fase03_BoxController>();
    }

    private void Update() {
        setText(getAttribute());
    }

    private float getAttribute(){
        float value = 0.0f;
        if (attribute == 0)
            value = sim.Rounds;
        else if (attribute == 1)
            value = sim.Radius_Motor;
        else if (attribute == 2)
            value = sim.Dynamic_Friction;
        else if (attribute == 3)
            value = Mathf.Abs(sim.Gravity);

        return value;
    }

    private void setText(float value){
        this.GetComponent<TMPro.TMP_Text>().text = value.ToString();
    }
}
