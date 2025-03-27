using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CircleEdge : MonoBehaviour
{

    public int vertexCount = 40;
    public float lineWidth = 0.2f;
    public float radius;
    public bool fillTheScreen;


    public LineRenderer _makeLine;
    void Awake()
    {
        print("Awake");
        
        _makeLine = GameObject.FindGameObjectWithTag("CircleEdge").GetComponent<LineRenderer>();
       
    }


    private void SetupCircle()
    {
        _makeLine.widthMultiplier = lineWidth;
        //if (fillTheScreen)
        //{
        //    radius =  Vector3.Distance(Camera.main.ScreenToWorldPoint(new Vector3(0f,Camera.main.pixelRect.yMax,0f)),
        //        Camera.main.ScreenToWorldPoint(new Vector3(0f, Camera.main.pixelRect.yMin,0f)) ) * 0.5f - lineWidth;
        //}

        float deltaTheta = (2f * Mathf.PI) / vertexCount;

        float theta = 0f;

        _makeLine.positionCount = vertexCount;
        for (int i =0; i < _makeLine.positionCount; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
            _makeLine.SetPosition(i, transform.position + pos);

            //oldPos = transform.position + pos;
            theta += deltaTheta;
        }
    }


    private void InitialStart()
    {
        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;
        Vector3 oldPos = Vector3.zero;

        for (int i = 0; i < vertexCount; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
            //Gizmos.DrawLine(oldPos, transform.position + pos);
            //_makeLine.SetPosition(oldPos, transform.position + pos);
            oldPos = transform.position + pos;
            theta += deltaTheta;
        }
    }


//#if UNITY_EDITOR
//    private void OnDrawGizmos()
//    {

//        float deltaTheta = (2f * Mathf.PI) / vertexCount;
//        float theta = 0f;
//        Vector3 oldPos = Vector3.zero;

//        for (int i = 0; i < vertexCount; i++)
//        {
//            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
//            Gizmos.DrawLine(oldPos, transform.position + pos);
//            //_makeLine.SetPosition(oldPos, transform.position + pos);
//            oldPos = transform.position + pos;
//            theta += deltaTheta;
//        }

//    }
//#endif
    // Start is called before the first frame update
    void Start()
    {
        print("Drawing Start!");
        //InitialStart();
        SetupCircle();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
