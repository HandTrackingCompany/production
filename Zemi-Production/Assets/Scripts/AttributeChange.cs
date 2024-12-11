using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AttributeChange : MonoBehaviour
{
    [SerializeField] GameObject throwObj;

    private bool _isBall;
    private bool _isBottle;
    private bool _isRod;
    readonly string _ballTag = "Ball";
    readonly string _ballLTag = "IronBall";
    readonly string _ballSTag = "Grenade";
    readonly string _ballPTag = "BowlingBall";
    readonly string _bottleTag = "Bottle";
    readonly string _bottleLTag = "Bin";
    readonly string _bottleSTag = "FireBin";
    readonly string _bottlePTag = "BowlingPin";
    readonly string _rodTag = "Rod";
    readonly string _rodLTag = "Baton";
    readonly string _rodSTag = "Spear";
    readonly string _rodPTag = "MetalBat";

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
        _isRod = false;
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
        else if (throwObj.CompareTag(_rodTag) || throwObj.CompareTag(_rodLTag) || throwObj.CompareTag(_rodSTag) ||
                 throwObj.CompareTag(_rodPTag))
        {
            _isRod = true;
        }
    }

    public void DeleteThrow()
    {
        throwObj = null;
        _isBall = false;
        _isBottle = false;
        _isRod = false;
    }
    public void ChangeLock()
    {
        if (_isBall == true)
        {
            throwObj.tag = "IronBall";
            throwObj.GetComponent<Renderer>().material.color = Color.yellow;
            //throwObj.GetComponent<MeshFilter>().mesh = lockBallMesh;
        }
        else if (_isBottle == true)
        {
            throwObj.tag = "Bin";
            throwObj.GetComponent<Renderer>().material.color = Color.cyan;
            //throwObj.GetComponent<MeshFilter>().mesh = lockBottleMesh;
        }
        else if (_isRod == true)
        {
            throwObj.tag = "Baton";
            throwObj.GetComponent<Renderer>().material.color = Color.magenta;
            //throwObj.GetComponent<MeshFilter>().mesh = lockRodMesh;
        }
    }

    public void ChangeScissors()
    {
        if (_isBall == true)
        {
            throwObj.tag = "Grenade";
            throwObj.GetComponent<Renderer>().material.color = Color.black;
            //throwObj.GetComponent<MeshFilter>().mesh = scissorsBallMesh;
        }
        else if (_isBottle == true)
        {
            throwObj.tag = "FireBin";
            throwObj.GetComponent<Renderer>().material.color = Color.red;
            //throwObj.GetComponent<MeshFilter>().mesh = scissorsBottleMesh;
        }
        else if (_isRod == true)
        {
            throwObj.tag = "Spear";
            throwObj.GetComponent<Renderer>().material.color = Color.white;
            //throwObj.GetComponent<MeshFilter>().mesh = scissorsRodMesh;
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
        else if (_isRod == true)
        {
            throwObj.tag = "MetalBat";
            throwObj.GetComponent<Renderer>().material.color = Color.clear;
            //throwObj.GetComponent<MeshFilter>().mesh = paperRodMesh;
        }
    }
}
