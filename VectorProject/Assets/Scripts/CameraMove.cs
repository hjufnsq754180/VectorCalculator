using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //public GameObject objectToOrbit;
    //public Vector3 direction;
    //public float angle;
    //public float radius;
    //public float degreesPerSecond = 10;
    //private void Start()
    //{
    //    direction = (transform.position - objectToOrbit.transform.position).normalized;
    //    radius = Vector3.Distance(objectToOrbit.transform.position, transform.position);
    //}
    //private void Update()
    //{
    //    angle += degreesPerSecond * Time.deltaTime;
    //    if (angle > 360)
    //    {
    //        angle -= 360;
    //    }
    //    Vector3 orbit = Vector3.forward * radius;
    //    orbit = Quaternion.LookRotation(direction) * Quaternion.Euler(0, angle, 0) * orbit;
    //    transform.position = objectToOrbit.transform.position + orbit;
    //    transform.position = new Vector3(transform.position.x, -5.5f, transform.position.z);
    //    transform.LookAt(objectToOrbit.transform);
    //}

    [SerializeField] Vector3 dir;

    private void Update()
    {
        
        dir.y = -Input.GetAxisRaw("Horizontal");
        dir.x = Input.GetAxisRaw("Vertical");

        transform.RotateAround(Vector3.zero, dir, 40f * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }
}
