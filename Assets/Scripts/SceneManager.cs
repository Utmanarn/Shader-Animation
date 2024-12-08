using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private EnvironmentSetupCompletePort _environmentSetupCompletePort;

    private EnvironmentSetup _environment;
    private PerformanceRecorder _performanceRecorder;

    private void OnEnable()
    {
        _environmentSetupCompletePort.EnvironmentSetup += StartTest;
    }

    private void OnDisable()
    {
        _environmentSetupCompletePort.EnvironmentSetup -= StartTest;
    }

    private void Start()
    {
        _environment = GetComponent<EnvironmentSetup>();
        _performanceRecorder = GetComponent<PerformanceRecorder>();
    }

    private void StartTest()
    {
        _performanceRecorder.Record();
    }

    private void Update()
    {
        _performanceRecorder.Record();
    }
}
