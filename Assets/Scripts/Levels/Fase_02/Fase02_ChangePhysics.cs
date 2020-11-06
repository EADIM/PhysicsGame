using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase02_ChangePhysics : MonoBehaviour
{
    public Fase02_References references;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate() {
        if(references.GameState.GetComponent<Fase02_GameState>().States[references.GameState.GetComponent<Fase02_GameState>().getSimulationName()]){
            Vector3 forca = transform.localScale.x * Physics.gravity;
            GetComponent<Rigidbody>().AddForce(forca, ForceMode.Acceleration);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
