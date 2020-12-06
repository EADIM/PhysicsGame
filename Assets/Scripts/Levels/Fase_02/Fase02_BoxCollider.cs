using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase02_BoxCollider : MonoBehaviour
{

    public GameObject ballObject;
    private Rigidbody ballProperties;
    public bool colidiu = false;

    private void OnCollisionEnter(Collision other) {

        if (!colidiu){
            colidiu = true;
        
            //Debug.Log(GetComponent<Renderer>().transform.position);
            
            ballProperties = ballObject.GetComponent<Rigidbody>();

            //Debug.LogFormat("V inicial: {0} {1} {2}" , ballProperties.velocity.x, ballProperties.velocity.y, ballProperties.velocity.z);

            float boxMass = GetComponent<Rigidbody>().mass;
            float ballMass = ballProperties.mass;

            float angleInRad = 45 * Mathf.Deg2Rad;
            float angleCos = Mathf.Cos(angleInRad);
            float angleSin = Mathf.Sin(angleInRad);

            float V = Mathf.Sqrt(((boxMass * 7.7f * 9.81f * 2)/(ballMass)));

            float Vy = V * angleSin;
            float Vz = V * angleCos;


            //Debug.Log("Massa da bola: " + ballMass + " --- Massa da caixa: " + boxMass);
            /*Debug.Log("Velocidade: " + V);
            Debug.Log("Vy: " + Vy + " --- Vz: " + Vz);*/

            Vector3 diagonal = new Vector3(0.0f, Vy, Vz);
            //4.845f - M = 5
            // 0.969f
            //0.9665f

            //4.98f = M = 10
            //4.98f*ballMass
            //ouro: 1.7654f
            //semiOuro: 8.827f
            //ouro2.0 = 0.8827f
            float value = 1.29f * ballMass * transform.localScale.x;

            Vector3 unidade = value*diagonal;

            //Debug.LogFormat("Vetor: {0} - {1} - {2}", unidade.x, unidade.y, unidade.z);
            ballObject.GetComponent<Rigidbody>().AddForce(value*diagonal, ForceMode.Impulse);

            //Debug.LogFormat("V final: {0} {1} {2}" , ballProperties.velocity.x, ballProperties.velocity.y, ballProperties.velocity.z);
        }

    }
}
