using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;

public class PerformanceRecorder : MonoBehaviour
{
    private Recorder _recorder;
    private float _elapsedMilliSec;
    private List<float> _elapsedMilisecondsList;
    public float averageTimeForCurrentSample;


    private void Start()
    {
        _elapsedMilisecondsList = new List<float>();
    }

    
    public void Record()
    {
        _recorder = Recorder.Get("Cube Sampler");
        

        if (_recorder.isValid)
        {
            _elapsedMilliSec = _recorder.elapsedNanoseconds * 0.000001f;
            _elapsedMilisecondsList.Add(_elapsedMilliSec);
            AverageMilliSec();
            PrintElapsedTime();
        }
        else
            Debug.LogWarning("Recorder is invalid.");
    }
    
    private void PrintElapsedTime()
    {
        Debug.Log("Time elapsed: " + _elapsedMilliSec);
    }

    private void AverageMilliSec() // Get the Average performance of the algorithm in milliseconds
    {
        averageTimeForCurrentSample = _elapsedMilisecondsList.Average();
    }

    public void ClearAverageList() // TODO: Clear after the sample is finished
    {
        _elapsedMilisecondsList.Clear();
    }
}