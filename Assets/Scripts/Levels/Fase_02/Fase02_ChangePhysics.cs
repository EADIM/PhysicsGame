using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase02_ChangePhysics : MonoBehaviour
{
    public Fase02_References references;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        if(references.GameState.GetComponent<Fase02_GameState>().States[references.GameState.GetComponent<Fase02_GameState>().getSimulationName()]){
            rb.isKinematic = false;
            Vector3 forca = transform.localScale.x * Physics.gravity;
            rb.AddForce(forca, ForceMode.Acceleration);
        }
        else{
            rb.isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
