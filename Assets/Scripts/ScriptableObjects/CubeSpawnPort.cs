using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CubeSpawnedPort", menuName = "ScriptableObjects/CubeSpawnedPort")]
public class CubesSpawnedPortObject : ScriptableObject
{
    public UnityAction CubesSpawned = delegate { };

    public void OnCubesSpawned()
    {
        CubesSpawned.Invoke();
    }
}