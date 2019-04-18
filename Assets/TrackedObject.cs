using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedObject : MonoBehaviour {

    public enum Hand {Left,Right};
    public Hand trackedController;
    public float pressed = 0;
    public float secondaryPressed = 0;
    public Transform node;
    private Transform prevParent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (trackedController == Hand.Right)
        {

            pressed = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
            secondaryPressed = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        }
        if (trackedController == Hand.Left)
        {

            pressed = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
            secondaryPressed = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        }
        if(secondaryPressed < 0.1f && node != null)
        {
            node.transform.parent = null;
            node = null;
        }
        if(secondaryPressed > 0.5f && node != null)
        {
            prevParent = node.transform.parent;
            node.transform.position = transform.position;
            node.transform.parent = transform;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.GetComponent<VirtualNode>() && node == null)
        {
            node = other.transform;
            prevParent = node.transform.parent;
        }
        print(other.transform);
    }
}
