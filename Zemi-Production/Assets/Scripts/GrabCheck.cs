using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCheck : MonoBehaviour
{
    private GameObject gesture;
    AttributeChange attributeChange;
    // Start is called before the first frame update
    void Start()
    {
        gesture = GameObject.Find("Gesture");
        attributeChange=gesture.GetComponent<AttributeChange>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        attributeChange.SetThrow(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        attributeChange.DeleteThrow();
    }
}
