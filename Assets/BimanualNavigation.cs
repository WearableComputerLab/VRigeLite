using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BimanualNavigation : MonoBehaviour {

    public TrackedObject t1;
    public TrackedObject t2;
    public Transform vrPerson;
    public float speed = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(t1.pressed > 0.5f && t2.pressed > 0.5f)
        {
            vrPerson.transform.position += ((t2.transform.position - t1.transform.position))*speed;
        }
	}
}
