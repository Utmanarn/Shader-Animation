using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "EnvironmentSetupCompletePort", menuName = "ScriptableObjects/EnvironmentSetupCompletePort")]
public class EnvironmentSetupCompletePort : ScriptableObject
{
    public UnityAction EnvironmentSetup;

    public void OnEnvironmentSetupCompleted()
    {
        EnvironmentSetup.Invoke();
    }
}