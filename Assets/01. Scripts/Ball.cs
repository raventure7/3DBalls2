using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public PhysicMaterial PMaterial;
    public int number = 0;

    private float speed = 1.3f;

    public Vector3 velocity;
    private Vector3 lastPos;
    private Vector3 pos3D;
    private Rigidbody rgd;
    private SphereCollider spc;
    public bool hooked;

	// Use this for initialization
	void Awake () {
        rgd = GetComponent<Rigidbody>();
        spc = GetComponent<SphereCollider>();
        rgd.velocity = Random.insideUnitCircle.normalized * speed;
        hooked = false;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        pos3D = transform.position;
        velocity = pos3D - lastPos;
        lastPos = pos3D;
        if(hooked == true)
        {
            //걸리면 위로 움직임.
            speed = 0.1f;
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.Rotate(0, 5, 0);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("MACHINE"))
        {
            Debug.Log("머신과 충돌");
        }
        if (collision.collider.CompareTag("BOTTOM"))
        {
            //Debug.Log("바닥과 충돌");
            //rgd.AddForce(new Vector3(0, 5, 0));

        }
        if (collision.collider.CompareTag("BALL") || collision.collider.CompareTag("BOTTOM"))
        {

            // 충돌지점
            Vector3 N = collision.contacts[0].normal;
            // 방향
            Vector3 V = velocity.normalized;
            // 반사
            Vector3 R = Vector3.Reflect(V, N).normalized;
            rgd.velocity = new Vector3(R.x, R.y, R.z) * speed;
            //rgd.AddForce(new Vector3(R.x, R.y, R.z) * speed);
            //spc.material = PMaterial;

        }




    }
 

}
