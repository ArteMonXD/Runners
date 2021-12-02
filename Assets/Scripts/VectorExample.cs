using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorExample : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public float speed;
    public bool resolution = true;
    private Vector3 target;
    void Start()
    {
        target = point1.position;
        transform.LookAt(target);
    }
    void Update()
    {
        transform.Rotate(0, 0, 1);
        if (resolution)
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

        if(transform.position == target)
        {
            if (target == point1.position)
            {
                target = point2.position;
            }
            else if(target == point2.position)
            {
                target = point1.position;
            }

            transform.LookAt(target);
        }
    }
}
