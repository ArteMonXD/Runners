using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarathonRunner : MonoBehaviour
{
    public MarathonSystem marathonSystem;
    public Vector3 targetPosition;
    public bool run = false;
    void Update()
    {
        if (run)
        {
            Rotate();
            Move();
            CheckDistance();
        }
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * marathonSystem.speedRunners);
    }
    private void Rotate()
    {
        transform.LookAt(targetPosition);
    }
    private void CheckDistance()
    {
        float currentDistance = Vector3.Distance(transform.position, targetPosition); 
        if (currentDistance < marathonSystem.passDistance)
        {
            run = false;
            marathonSystem.SwitchRunner();
        }
    }
}
