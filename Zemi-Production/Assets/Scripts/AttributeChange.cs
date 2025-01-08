using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AttributeChange : MonoBehaviour
{
    [SerializeField] GameObject throwObj;

    public bool _isBall;
    public bool _isBottle;
    //public bool _isRod;
    readonly string _ballTag = "Ball";
    readonly string _ballLTag = "IronBall";
    readonly string _ballSTag = "Grenade";
    readonly string _ballPTag = "BowlingBall";
    readonly string _bottleTag = "Bottle";
    readonly string _bottleLTag = "Bin";
    readonly string _bottleSTag = "FireBin";
    readonly string _bottlePTag = "BowlingPin";
    // readonly string _rodTag = "Rod";
    // readonly string _rodLTag = "Baton";
    // readonly string _rodSTag = "Spear";
    // readonly string _rodPTag = "MetalBat";

    [SerializeField] Mesh lockBallMesh;
    [SerializeField] Mesh scissorsBallMesh;
    [SerializeField] Mesh paperBallMesh;
    
    [SerializeField] Mesh lockBottleMesh;
    [SerializeField] Mesh scissorsBottleMesh;
    [SerializeField] Mesh paperBottleMesh;
    
    [SerializeField] Mesh lockRodMesh;
    [SerializeField] Mesh scissorsRodMesh;
    [SerializeField] Mesh paperRodMesh;

    // Start is called before the first frame update
    void Start()
    {
        _isBall = false;
        _isBottle = false;
        //_isRod = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetThrow(GameObject obj)
    {
        throwObj = obj;
        Debug.Log("SetThrow:"+obj.name+"/"+throwObj.name);

        if (throwObj.CompareTag(_ballTag)||throwObj.CompareTag(_ballLTag)||throwObj.CompareTag(_ballSTag)||throwObj.CompareTag(_ballPTag))
        {
            _isBall = true;
        }
        else if (throwObj.CompareTag(_bottleTag)||throwObj.CompareTag(_bottleLTag)||throwObj.CompareTag(_bottleSTag)||throwObj.CompareTag(_bottlePTag))
        {
            _isBottle = true;
        }
        // else if (throwObj.CompareTag(_rodTag) || throwObj.CompareTag(_rodLTag) || throwObj.CompareTag(_rodSTag) ||
        //          throwObj.CompareTag(_rodPTag))
        // {
        //     _isRod = true;
        // }
    }

    public void DeleteThrow()
    {
        throwObj = null;
        _isBall = false;
        _isBottle = false;
        //_isRod = false;
    }
    public void ChangeLock()
    {
        if (_isBall == true)
        {
            throwObj.tag = _ballLTag;
            throwObj.GetComponent<Renderer>().material.color = Color.yellow;
            //throwObj.GetComponent<MeshFilter>().mesh = lockBallMesh;
        }
        else if (_isBottle == true)
        {
            throwObj.tag = _bottleLTag;
            throwObj.GetComponent<Renderer>().material.color = Color.cyan;
            //throwObj.GetComponent<MeshFilter>().mesh = lockBottleMesh;
        }
    }

    public void ChangeScissors()
    {
        if (_isBall == true)
        {
            throwObj.tag = _ballSTag;
            throwObj.GetComponent<Renderer>().material.color = Color.black;
            //throwObj.GetComponent<MeshFilter>().mesh = scissorsBallMesh;
        }
        else if (_isBottle == true)
        {
            throwObj.tag = _bottleSTag;
            throwObj.GetComponent<Renderer>().material.color = Color.red;
            //throwObj.GetComponent<MeshFilter>().mesh = scissorsBottleMesh;
        }
    }

    public void ChangePaper()
    {
        if (_isBall == true)
        {
            throwObj.tag = "BowlingBall";
            throwObj.GetComponent<Renderer>().material.color = Color.blue;
            //throwObj.GetComponent<MeshFilter>().mesh = paperBallMesh;
        }
        else if (_isBottle == true)
        {
            throwObj.tag = "BowlingPin";
            throwObj.GetComponent<Renderer>().material.color = Color.gray;
            //throwObj.GetComponent<MeshFilter>().mesh = paperBottleMesh;
        }
    }
}
