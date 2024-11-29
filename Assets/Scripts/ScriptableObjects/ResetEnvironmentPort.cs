using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ResetEnvironment", menuName = "ScriptableObjects/ResetEnvironment")]
public class ResetEnvironmentPort : ScriptableObject
{
    public UnityAction ResetEnvironment = delegate { };

    public void OnEnvironmentReset()
    {
        ResetEnvironment.Invoke();
    }
}