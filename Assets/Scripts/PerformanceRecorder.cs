using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;

public class PerformanceRecorder : MonoBehaviour
{
    private Recorder _recorder;
    private float _elapsedMilliSec;
    private List<float> _elapsedMilisecondsList;
    public float averageTimeForCurrentSample { get; private set; }


    private void Start()
    {
        _elapsedMilisecondsList = new List<float>();
    }

    
    public void Record()
    {
        _recorder = Recorder.Get(""); // TODO: It isn't recording!
        

        if (_recorder.isValid)
        {
            _elapsedMilliSec = _recorder.gpuElapsedNanoseconds * 0.000001f; // GPU elapsed has a delay of 3 frames. This collects data from 3 frames ago when called.
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