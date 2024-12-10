using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PerformanceRecorder : MonoBehaviour
{
    private float _elapsedFrameMilliSec;
    private float _elapsedRenderMilliSec;
    private List<float> _elapsedFrameMilisecondsList;
    private List<float> _elapsedRenderMilisecondsList;
    public float averageFrameTimeForCurrentSample { get; private set; }
    public float averageRenderTimeForCurrentSample { get; private set; }


    private void Start()
    {
        _elapsedFrameMilisecondsList = new List<float>();
        _elapsedRenderMilisecondsList = new List<float>();
    }

    
    public void Record()
    {
        _elapsedFrameMilisecondsList.Add(UnityEditor.UnityStats.frameTime * 1000);
        _elapsedRenderMilisecondsList.Add(UnityEditor.UnityStats.renderTime * 1000);

        AverageMilliSec();

        /*
        FrameTiming[] frameTimings = new FrameTiming[1];
        FrameTimingManager.CaptureFrameTimings();

        if (FrameTimingManager.GetLatestTimings(1, frameTimings) > 0)
        {
            float cpuTime = (float)frameTimings[0].cpuFrameTime;
            float gpuTime = (float)frameTimings[0].gpuFrameTime;

            Debug.Log($"Frame: {Time.frameCount}, CPU Time: {cpuTime} ms, GPU Time: {gpuTime} ms");
        }*/

        /*
        if (_recorder.isValid)
        {
            _elapsedMilliSec = _recorder.gpuElapsedNanoseconds * 0.000001f; // GPU elapsed has a delay of 3 frames. This collects data from 3 frames ago when called.
            _elapsedMilisecondsList.Add(_elapsedMilliSec);
            AverageMilliSec();
            PrintElapsedTime();
        }
        else
            Debug.LogWarning("Recorder is invalid.");
        */
    }
    
    private void PrintElapsedTime()
    {
        Debug.Log("Time elapsed CPU: " + _elapsedFrameMilliSec);
        Debug.Log("Time elapsed GPU: " + _elapsedRenderMilliSec);
    }

    private void AverageMilliSec() // Get the Average performance of the algorithm in milliseconds
    {
        averageFrameTimeForCurrentSample = _elapsedFrameMilisecondsList.Average();
        averageRenderTimeForCurrentSample = _elapsedRenderMilisecondsList.Average();
    }

    public void ClearAverageList() // TODO: Clear after the sample is finished
    {
        _elapsedFrameMilisecondsList.Clear();
        _elapsedRenderMilisecondsList.Clear();
    }
}