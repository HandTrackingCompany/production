using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeChange : MonoBehaviour
{
    [SerializeField] GameObject throwObj;
    private GameObject Boss;
    private Vector3 current;
    private Rigidbody objRb;

    private bool _isBall;
    private bool _isBottle;
    readonly string _ballTag = "Ball";
    readonly string _ballLTag = "IronBall";
    readonly string _ballSTag = "Grenade";
    readonly string _ballPTag = "BowlingBall";
    readonly string _bottleTag = "Bottle";
    readonly string _bottleLTag = "Bin";
    readonly string _bottleSTag = "FireBin";
    readonly string _bottlePTag = "BowlingPin";

    [SerializeField] Material lockBallMaterial;
    [SerializeField] Material scissorsBallMaterial;
    [SerializeField] Material paperBallMaterial;
    
    [SerializeField] Material lockBottleMaterial;
    [SerializeField] Material scissorsBottleMaterial;
    [SerializeField] Material paperBottleMaterial;

    // Start is called before the first frame update
    void Start()
    {
        _isBall = false;
        _isBottle = false;
        Boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetThrow(GameObject obj)
    {
        throwObj = obj;

        if (throwObj.CompareTag(_ballTag)||throwObj.CompareTag(_ballLTag)||throwObj.CompareTag(_ballSTag)||throwObj.CompareTag(_ballPTag))
        {
            _isBall = true;
        }
        else if (throwObj.CompareTag(_bottleTag)||throwObj.CompareTag(_bottleLTag)||throwObj.CompareTag(_bottleSTag)||throwObj.CompareTag(_bottlePTag))
        {
            _isBottle = true;
        }
    }

    public void Shot()
    {
        if (throwObj != null)
        {
            objRb = throwObj.GetComponent<Rigidbody>();
            throwObj.GetComponent<Collider>().isTrigger = true;
            objRb.AddForce(0,0,500);
        }
        /*var target = Boss.transform.position;
        if (throwObj != null)
        {
            current = throwObj.transform.position;
            float speed = 2.0f * Time.deltaTime;
            ShotItem(throwObj,current,target,speed);
        }*/
    }

    private void ShotItem(GameObject obj,Vector3 current,Vector3 target,float speed)
    {
        while (obj.transform.position == target)
        {
            obj.transform.position = Vector3.MoveTowards(current, target, speed);
        }
    }
    

    public void DeleteThrow()
    {
        throwObj = null;
        _isBall = false;
        _isBottle = false;
    }
    public void ChangeLock()
    {
        if (_isBall == true)
        {
            throwObj.tag = "IronBall";
            throwObj.GetComponent<Renderer>().material.color = Color.yellow;
            //throwObj.GetComponent<Renderer>().material = lockBallMaterial;
        }
        else if (_isBottle == true)
        {
            throwObj.tag = "Bin";
            throwObj.GetComponent<Renderer>().material.color = Color.cyan;
            //throwObj.GetComponent<Renderer>().material = lockBottleMaterial;
        }
    }

    public void ChangeScissors()
    {
        if (_isBall == true)
        {
            throwObj.tag = "Grenade";
            throwObj.GetComponent<Renderer>().material.color = Color.black;
            //throwObj.GetComponent<Renderer>().material = scissorsBallMaterial;
        }
        else if (_isBottle == true)
        {
            throwObj.tag = "FireBin";
            throwObj.GetComponent<Renderer>().material.color = Color.red;
            //throwObj.GetComponent<Renderer>().material = scissorsBottleMaterial;
        }
    }

    public void ChangePaper()
    {
        if (_isBall == true)
        {
            throwObj.tag = "BowlingBall";
            throwObj.GetComponent<Renderer>().material.color = Color.blue;
            //throwObj.GetComponent<Renderer>().material = paperBallMaterial;
        }
        else if (_isBottle == true)
        {
            throwObj.tag = "BowlingPin";
            throwObj.GetComponent<Renderer>().material.color = Color.gray;
            //throwObj.GetComponent<Renderer>().material = paperBottleMaterial;
        }
    }
}
