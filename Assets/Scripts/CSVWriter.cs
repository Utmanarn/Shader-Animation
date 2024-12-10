using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVWriter : MonoBehaviour
{
    private string _filePath;

    // Start is called before the first frame update
    void Start()
    {
        _filePath = Application.dataPath + "/output.csv";
        CreateCSV();
    }

    private void CreateCSV()
    {
        using (StreamWriter streamWriter = new StreamWriter(_filePath, false))
        {
            streamWriter.WriteLine("CubeCount; RenderTime; FrameTime");
            streamWriter.Close();
        }
    }

    public void WriteToCSV(List<int> cubeCount, List<float> renderTime, List<float> frameTime)
    {
        using (StreamWriter streamWriter = new StreamWriter(_filePath, true))
        {
            for (int i = 0; i < cubeCount.Count; i++)
            {
                streamWriter.Write(cubeCount[i] + "; ");
                if (renderTime != null && renderTime.Count > i)
                {
                    streamWriter.Write(renderTime[i] + "; ");
                }
                else
                {
                    streamWriter.Write("0" + "; ");
                }
                if (frameTime != null && frameTime.Count > i)
                {
                    streamWriter.Write(frameTime[i]);
                }
                else
                {
                    streamWriter.Write("0");
                }
            }

            streamWriter.Close();
        }

        Application.Quit();
    }
}
