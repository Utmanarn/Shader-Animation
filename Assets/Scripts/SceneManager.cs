using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    //[SerializeField] private EnvironmentSetupCompletePort _environmentSetupCompletePort;

    private EnvironmentSetup _environment;
    private PerformanceRecorder _performanceRecorder;
    private CSVWriter _CSVWriter;

    private List<int> _cubeCount;
    private List<float> _averageRenderTime;
    private List<float> _averageFrameTime;

    private bool _hasWrittenToCSV = false;

    private int _timer;
    private int _timerMaxFrames = 1000;

    private int _maxRuntime;
    [SerializeField, Tooltip("Max number of frames the program is allowed to run for.")] private int _maxRuntimeAllowed = 200000;

    private void Start()
    {
        _cubeCount = new List<int>();
        _averageFrameTime = new List<float>();
        _averageRenderTime = new List<float>();
        _CSVWriter = GetComponent<CSVWriter>();
        _environment = GetComponent<EnvironmentSetup>();
        _performanceRecorder = GetComponent<PerformanceRecorder>();
    }

    private void Update()
    {
        if (_hasWrittenToCSV) return;
        
        if (_timer < _timerMaxFrames)
        {
            _performanceRecorder.Record();
            _timer++;
            _maxRuntime++;
        }
        else
        {
            _timer = 0;
            _cubeCount.Add(_environment._cubeSpawnCurrent);
            _averageFrameTime.Add(_performanceRecorder.averageFrameTimeForCurrentSample);
            _averageRenderTime.Add(_performanceRecorder.averageRenderTimeForCurrentSample);
            _performanceRecorder.ClearAverageList();
            _environment.ResetEnvironment();
        }

        if (_maxRuntime > _maxRuntimeAllowed)
        {
            _CSVWriter.WriteToCSV(_cubeCount, _averageRenderTime, _averageFrameTime);
            _environment.EndSimulation();

            _hasWrittenToCSV = true;
        }
    }
}
