using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarathonSystem : MonoBehaviour
{
    public Transform relayRace;
    private Vector3 localPositionRelayRace;
    private Quaternion localRotationRelayRace;
    public Transform[] runners;
    private Vector3[] startPositions;
    public float passDistance;
    public float speedRunners;
    private int _currentRunner;
    private int _targetRunner;
    public GameObject startButton;
    public GameObject restartButton;
    public Text parameterText;
    void Start()
    {
        localPositionRelayRace = relayRace.localPosition;
        localRotationRelayRace = relayRace.localRotation;
        startPositions = new Vector3[runners.Length];
        for(int i = 0; i<runners.Length; i++)
        {
            startPositions[i] = runners[i].localPosition;
        }
        ShowMarathonState();
    }
    public void SwitchRunner()
    {
        if ((_currentRunner + 1) == (runners.Length - 1))
        {
            _currentRunner++;
            _targetRunner = 0;
        }
        else if(_currentRunner == (runners.Length - 1))
        {
            _currentRunner = 0;
            _targetRunner++;
        }
        else
        {
            _currentRunner++;
            _targetRunner++;
        }
        ShowMarathonState();
        PassingTheBaton();
        SetStartRunner();
    }
    public void StartMarathon()
    {
        _targetRunner = _currentRunner+1;
        SetStartRunner();
        SwithButtons();
    }
    public void RestartMarathon()
    {
        for(int i = 0; i<runners.Length; i++)
        {
            runners[i].GetComponent<MarathonRunner>().run = false;
            runners[i].position = startPositions[i];
            runners[i].rotation = Quaternion.Euler(0, 0, 0);
        }
        _currentRunner = 0;
        ShowMarathonState();
        PassingTheBaton();
        SwithButtons();
    }
    private void PassingTheBaton()
    {
        relayRace.SetParent(runners[_currentRunner]);
        relayRace.localPosition = localPositionRelayRace;
        relayRace.localRotation = localRotationRelayRace;
    }
    private void SetStartRunner()
    {
        MarathonRunner currentRunner = runners[_currentRunner].GetComponent<MarathonRunner>();
        currentRunner.targetPosition = runners[_targetRunner].position;
        currentRunner.run = true;
    }
    private void SwithButtons()
    {
        startButton.SetActive(!startButton.activeSelf);
        restartButton.SetActive(!restartButton.activeSelf);
    }
    private void ShowMarathonState()
    {
        parameterText.text = $"Номер бегуна: {(_currentRunner + 1)}";
    }
}
