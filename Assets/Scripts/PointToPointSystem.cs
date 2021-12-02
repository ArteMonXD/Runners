using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointToPointSystem : MonoBehaviour
{
    [SerializeField] private int pointCount;
    [SerializeField] private Vector3[] points;
    [SerializeField] private bool forward = true;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int _currentPoint;
    private bool resolution = false;
    public GameObject startButton;
    public GameObject restartButton;
    public Text parameterText;
    void Start()
    {
        points = new Vector3[pointCount];
        for(int i = 0; i<pointCount; i++)
        {
            points[i] = new Vector3(Random.Range(-10.0f, 10.1f), 0f, Random.Range(-10.0f, 10.1f));
        }
        transform.LookAt(points[_currentPoint]);
    }
    void Update()
    {
        if (resolution)
        {
            Move();
            if (transform.position == points[_currentPoint])
            {
                SwitchTarget();
            }
        }
        ShowCurrentPoint();
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[_currentPoint], Time.deltaTime * moveSpeed);
    }
    private void SwitchTarget()
    {
        if (forward)
        {
            if (_currentPoint == (pointCount - 1))
            {
                forward = !forward;
                _currentPoint--;
            }
            else
                _currentPoint++;
        }
        else
        {
            if (_currentPoint == 0)
            {
                forward = !forward;
                _currentPoint++;
            }
            else
                _currentPoint--;
        }
        transform.LookAt(points[_currentPoint]);
    }
    private void ShowCurrentPoint()
    {
        parameterText.text = $"Номер текущей точки: {(_currentPoint+1)}";
    }
    public void StartButton()
    {
        resolution = true;
        startButton.SetActive(false);
        restartButton.SetActive(true);
    }
    public void RestartButton()
    {
        resolution = false;
        _currentPoint = 0;
        forward = true;
        transform.position = Vector3.zero;
        for (int i = 0; i < pointCount; i++)
        {
            points[i] = new Vector3(Random.Range(-10.0f, 10.1f), 0f, Random.Range(-10.0f, 10.1f));
        }
        transform.LookAt(points[_currentPoint]);
        startButton.SetActive(true);
        restartButton.SetActive(false);
    }
}
