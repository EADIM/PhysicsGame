using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase03_MoveBoxUp : MonoBehaviour
{

    private float movementSpeed = 0.2f;

    public bool moveUp;
    public bool moveDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveUp){
            float horizontalInput =-(transform.localScale.x*5f);

            transform.position = transform.position + new Vector3(horizontalInput*movementSpeed*Time.deltaTime, 0, 0);

            Debug.Log(transform.position);
        }
        else if (moveDown){
            float horizontalInput =(transform.localScale.x*5f);

            transform.position = transform.position + new Vector3(horizontalInput*movementSpeed*Time.deltaTime, 0, 0);

            Debug.Log(transform.position);
        }
    }
}
