using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSetup : MonoBehaviour
{
    [SerializeField] private CubesSpawnedPortObject cubesSpawnedPort;

    [SerializeField, Tooltip("True will spawn animated cube and False will spawn shader animated cube.")] private bool CubeTypeSwitcher;

    [SerializeField] private GameObject _animCube;
    [SerializeField] private GameObject _shadeCube;
    [SerializeField] private int _maxCubesToSpawnOnNewItteration = 10;
    private int _cubeSpawnedAmount = 0;
    private int _cubeSpawnCurrent;
    private float _spawnAxisX, _spawnAxisZ;

    private static List<GameObject> _cubeList;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Start()
    {
        _cubeList = new List<GameObject>();

        _spawnAxisX = 0f;
        _spawnAxisZ = 0f;

        _cubeSpawnedAmount = _maxCubesToSpawnOnNewItteration;

        SetupEnvironment();
    }

    public void FullEnvironmentReset()
    {
        _cubeSpawnedAmount = _maxCubesToSpawnOnNewItteration;
        ResetEnvironment();
    }

    public void ResetEnvironment()
    {
        for (int i = _cubeList.Count - 1; i >= 0; i--)
        {
            GameObject cube = _cubeList[i];
            _cubeList.RemoveAt(i);

            Destroy(cube);
        }

        _cubeSpawnCurrent = 0;
        _spawnAxisX = 0f;
        _spawnAxisZ = 0f;

        SetupEnvironment();
    }

    private void SetupEnvironment()
    {
        while (_cubeSpawnCurrent < _cubeSpawnedAmount)
        {
            SpawnCube();
            _cubeSpawnCurrent++;
        }

    }

    private void SpawnCube()
    {
        GameObject localCube;

        if (CubeTypeSwitcher)
            localCube = Instantiate(_animCube, new Vector3(_spawnAxisX, 0, _spawnAxisZ), Quaternion.identity);
        else
            localCube = Instantiate(_shadeCube, new Vector3(_spawnAxisX, 0, _spawnAxisZ), Quaternion.identity);

        _cubeList.Add(localCube);

        _spawnAxisX++;
        if (_spawnAxisX > 10f)
        {
            _spawnAxisZ++;
            _spawnAxisX = 0;
        }
    }
}
