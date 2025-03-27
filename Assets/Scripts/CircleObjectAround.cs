using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CircleObjectAround : MonoBehaviour
{

    public MoveObjectTmp _circle;


    public Transform _target;

    [Range(0, 1)]
    public float _version;

    Quaternion _rotation1;

    Quaternion _rotation2;
    [SerializeField]
    private float _rotationSpeed = 45f;

    [SerializeField]
    private Transform _mainPosition;

    private bool autoRotate = false;

    // Start is called before the first frame update
    void Start()
    {
        //_rotation1 = Quaternion.Euler(0, 0, 0);

        //_rotation2 = Quaternion.Euler(0, 0, -180);
        ////_target = transform.rotation;
        //_target.position = new Vector3(_circle.radius, 0f, 0f);
        //_target.rotation = Quaternion.Slerp(_rotation1, _rotation2, _version);

        //_target.rotation = new Vector3(0f, 0f, 90f);
    }

    // Update is called once per frame
    void Update()
    {

        

        Vector3 positionTemp = new Vector3(_mainPosition.position.x, _mainPosition.position.y, 0);
        _target.RotateAround(positionTemp, Vector3.forward, -_rotationSpeed * Time.deltaTime);

        //_target.Rotate( Vector3.forward, -_rotationSpeed * Time.deltaTime);
        //if (Input.GetKey(KeyCode.F))
        //{
        //    print("f down");

        //}

    }
}
