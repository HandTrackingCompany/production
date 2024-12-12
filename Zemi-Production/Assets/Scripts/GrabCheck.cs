using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCheck : MonoBehaviour
{
    private GameObject gesture;
    [SerializeField] AttributeChange attributeChange;
    private GameObject Bullet;
    private GameObject Boss;
    private bool shot = false;
    private string ballTag = "Ball";
    private string bottleTag = "Bottle";

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
        
        attributeChange._isBall = false;
        attributeChange._isBottle = false;
        attributeChange._isRod = false;
    }

    public void Cancel()
    {
        shot = false;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ballTag) || other.CompareTag(bottleTag))
        {
            attributeChange.SetThrow(other.gameObject);
                    Bullet = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug .Log("Exit");
        //attributeChange.DeleteThrow();
    }
}
