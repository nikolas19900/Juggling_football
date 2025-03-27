using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class MoveObjectTmp : MonoBehaviour
{

    public int vertexCount = 40;
    public float lineWidth = 0.2f;
    public float radius;
    public bool fillTheScreen;
    public LineRenderer _makeLine;
    // Start is called before the first frame update
    void Start()
    {
        //DrawCircle(50, 3);
        SetupCircle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void SetupCircle()
    {
        //_makeLine.positionCount = steps;
        _makeLine.widthMultiplier = lineWidth;
        //if (fillTheScreen)
        //{
        //    radius =  Vector3.Distance(Camera.main.ScreenToWorldPoint(new Vector3(0f,Camera.main.pixelRect.yMax,0f)),
        //        Camera.main.ScreenToWorldPoint(new Vector3(0f, Camera.main.pixelRect.yMin,0f)) ) * 0.5f - lineWidth;
        //}
        
          

       // float deltaTheta = (2f * Mathf.PI) / vertexCount;

        //float theta = 0f;

        _makeLine.positionCount = vertexCount;
        for (int i = 0; i < _makeLine.positionCount; i++)
        {
            float progress = (float)i / vertexCount;
            float radian = progress * 2 * Mathf.PI;

            //Vector3 pos = new Vector3(radius * Mathf.Cos(radian), radius * Mathf.Sin(radian), 0f);
            //_makeLine.SetPosition(i, transform.position + pos);


            float xScaled = Mathf.Cos(radian);
            float yScaled = Mathf.Sin(radian);


            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x, y);

            _makeLine.SetPosition(i, currentPosition);

            //oldPos = transform.position + pos;
            //theta += deltaTheta;
        }
    }

    void DrawCircle(int steps, float radius)
    {
        _makeLine.positionCount = steps;

        
        for (int cuurentStep =0; cuurentStep < steps; cuurentStep++) {
            float progress = (float)cuurentStep / steps;
            float radian = progress * 2 * Mathf.PI;


            float xScaled = Mathf.Cos(radian);
            float yScaled = Mathf.Sin(radian);


            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x,y);

            _makeLine.SetPosition(cuurentStep, currentPosition);
        }
    }
}
