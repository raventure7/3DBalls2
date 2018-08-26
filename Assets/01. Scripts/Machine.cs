using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour {
    private float speed = 2.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


    }
    private void OnCollisionEnter(Collision collision)
    {
        // 입사벡터를 알아본다. (충돌할때 충돌한 물체의 입사 벡터 노말값)
        Vector3 incomingVector = collision.gameObject.GetComponent<Ball>().velocity.normalized;
        incomingVector = incomingVector.normalized;
        // 충돌한 면의 법선 벡터를 구해낸다.
        Vector3 normalVector = collision.contacts[0].normal;
        // 법선 벡터와 입사벡터을 이용하여 반사벡터를 알아낸다.
        Vector3 reflectVector = Vector3.Reflect(incomingVector, normalVector); //반사각
        reflectVector = reflectVector.normalized;
        Debug.Log(reflectVector);
        collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(reflectVector.x, reflectVector.y, reflectVector.z) * speed;
        /*
                if (collision.collider.CompareTag("BALL"))
                {

                    // 충돌지점
                    Vector3 N = collision.contacts[0].normal;
                    Debug.Log("Ball 충돌 1 :" + N);
                    // 방향
                    Vector3 V = collision.gameObject.GetComponent<Ball>().velocity.normalized;
                    // 반사
                    Vector3 R = Vector3.Reflect(V, N).normalized;
                    collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(R.x, R.y, R.z) * speed;
                    //collision.gameObject.GetComponent<Rigidbody>().velocity = Random.insideUnitCircle.normalized * speed;
                    //collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.15f, 0.15f, 0.15f);
                    //collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-0.25f, -0.25f, -0.25f));
                }
        */
    }
}
