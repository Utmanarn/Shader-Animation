using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class EnvironmentSetup : MonoBehaviour
{
    [SerializeField] private CubesSpawnedPortObject cubesSpawnedPort;
    [SerializeField] private ResetEnvironmentPort resetEnvironmentPort;
    [SerializeField] private EnvironmentSetupCompletePort environmentSetupCompletePort;

    [SerializeField, Tooltip("True will spawn animated cube and False will spawn shader animated cube.")] private bool _cubeTypeSwitcher;

    [SerializeField] private GameObject _animCube;
    [SerializeField] private GameObject _shadeCube;
    [SerializeField] private int _maxCubesToSpawnOnNewItteration = 10;
    private int _cubeSpawnedAmount = 0;
    public int _cubeSpawnCurrent { get; private set; } = 0;
    private float _spawnAxisX, _spawnAxisZ;

    private static List<GameObject> _cubeList;

    private void OnEnable()
    {
        resetEnvironmentPort.ResetEnvironment += ResetEnvironment;
    }

    private void OnDisable()
    {
        resetEnvironmentPort.ResetEnvironment -= ResetEnvironment;
    }

    private void Start()
    {
        _cubeList = new List<GameObject>();

        _spawnAxisX = -15f;
        _spawnAxisZ = 0f;

        _cubeSpawnedAmount = _maxCubesToSpawnOnNewItteration;

        SetupEnvironment();
    }

    public void EndSimulation()
    {

    }

    public void FullEnvironmentReset()
    {
        _cubeSpawnedAmount = _maxCubesToSpawnOnNewItteration;
        ResetEnvironment();
    }

    public void ResetEnvironment()
    {
        for (int i = _cubeList.Count - 1; i >= 0; i--) // For this experiment we might not need to delete the already spawned cubes to save time on spawning them all again. They might get unsynced in rotation but that should not be a problem.
        {
            GameObject cube = _cubeList[i];
            _cubeList.RemoveAt(i);

            Destroy(cube);
        }

        _cubeSpawnCurrent = 0;
        _spawnAxisX = 0f;
        _spawnAxisZ = 0f;

        _cubeSpawnedAmount += _maxCubesToSpawnOnNewItteration;

        SetupEnvironment();
    }

    private void SetupEnvironment()
    {
        while (_cubeSpawnCurrent < _cubeSpawnedAmount)
        {
            SpawnCube();
            _cubeSpawnCurrent++;
        }
        cubesSpawnedPort.OnCubesSpawned();

        environmentSetupCompletePort.OnEnvironmentSetupCompleted();
    }

    private void SpawnCube()
    {
        GameObject localCube;

        if (_cubeTypeSwitcher)
            localCube = Instantiate(_animCube, new Vector3(_spawnAxisX, 0, _spawnAxisZ), Quaternion.identity);
        else
            localCube = Instantiate(_shadeCube, new Vector3(_spawnAxisX, 0, _spawnAxisZ), Quaternion.identity);

        _cubeList.Add(localCube);

        _spawnAxisX += 2f;
        if (_spawnAxisX >= 10f)
        {
            _spawnAxisZ += 2f;
            _spawnAxisX = -15f;
        }
    }
}
