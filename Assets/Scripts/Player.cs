using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Player : MonoBehaviour {

    public float rotationDelta = 30,
        transformDelta = 30;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();

        MapManager.Instance.HelloWorld();
	}
	
	// Update is called once per frame
	void Update () {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float newRot = transform.rotation.y + h * Time.deltaTime;
        transform.Rotate(Vector3.up * h * rotationDelta * Time.deltaTime);
        
        Vector3 newTrans = transform.forward * v * Time.deltaTime;
        transform.position += newTrans;
	}
}
