using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCheck : MonoBehaviour
{
    private GameObject gesture;
    AttributeChange attributeChange;
    private GameObject Bullet;
    private GameObject Boss;
    private bool shot = false;

    [SerializeField] private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        gesture = GameObject.Find("Gesture");
        attributeChange=gesture.GetComponent<AttributeChange>();
        Boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        if (shot && Bullet)
        {
            Bullet.transform.position =
                Vector3.MoveTowards(Bullet.transform.position, 
                    Boss.transform.position, speed * Time.deltaTime);
        }   
    }

    public void Shoot()
    {
        shot = true;
    }

    public void Cancel()
    {
        shot = false;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        attributeChange.SetThrow(other.gameObject);
        Bullet = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        attributeChange.DeleteThrow();
    }
}
