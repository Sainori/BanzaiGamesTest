using EnemyServices.Interfaces;
using InputServices.Interfaces;
using MapServices.Interfaces;
using TankServices.Interfaces;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private IMapController _mapController;
    private ITankController _tankController;
    private IInputController _inputController;
    private IEnemyController _enemyController;


    private void Awake()
    {
        _mapController = gameObject.GetComponent<IMapController>();
        _tankController = gameObject.GetComponent<ITankController>();
        _inputController = gameObject.GetComponent<IInputController>();
        _enemyController = gameObject.GetComponent<IEnemyController>();
    }

    private void Start()
    {
        SetupScene();
    }

    private void SetupScene()
    {
        _mapController.CreateMap();
        _inputController.OnRestart += Restart;
        var tank = _tankController.CreteTank(_inputController, _mapController.GetPlayerSpawnPoint());
        _enemyController.Initialize(_mapController.GetEnemySpawnPoints(), tank);
    }

    private void DeleteScene()
    {
        _enemyController.DeleteEnemies();
        _inputController.Reset();
        _tankController.DeleteTank();
        _mapController.DeleteMap();
    }

    private void Update()
    {
        _inputController.DirectUpdate();
    }

    private void FixedUpdate()
    {
        _tankController.DirectUpdate();
        _enemyController.DirectUpdate();
    }

    private void OnDestroy()
    {
        _inputController.OnRestart  = () => { };
    }

    private void Restart()
    {
        Time.timeScale = 0;
        DeleteScene();
        SetupScene();
        Time.timeScale = 1;
    }
}
