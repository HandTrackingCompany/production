using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeChange : MonoBehaviour
{
    [SerializeField] GameObject throwObj;

    [SerializeField] Material lockMaterial;
    [SerializeField] Material scissorsMaterial;
    [SerializeField] Material paperMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetThrow(GameObject obj)
    {
        throwObj = obj;
    }

    public void DeleteThrow()
    {
        throwObj = null;
    }
    public void ChangeLock()
    {
        throwObj.GetComponent<Renderer>().material = lockMaterial;
    }

    public void ChangeScissors()
    {
        throwObj.GetComponent<Renderer>().material = scissorsMaterial; ;
    }

    public void ChangePaper()
    {
        throwObj.GetComponent<Renderer>().material = paperMaterial; ;
    }
}
