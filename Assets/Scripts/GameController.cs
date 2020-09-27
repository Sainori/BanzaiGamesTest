using System;
using EnemyServices.Interfaces;
using InputServices.Interfaces;
using MapServices;
using MapServices.Interfaces;
using TankServices;
using TankServices.Interfaces;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private IMapController _mapController;
    private ITankController _tankController;
    private IInputController _inputController;
    private IEnemyController _enemyController;

    private Tank _tank;

    private void Awake()
    {
        _mapController = gameObject.GetComponent<IMapController>();
        _tankController = gameObject.GetComponent<ITankController>();
        _inputController = gameObject.GetComponent<IInputController>();
        _enemyController = gameObject.GetComponent<IEnemyController>();
    }

    private void Start()
    {
        _mapController.CreateMap();
        _enemyController.Initialize(_mapController.GetEnemySpawnPoints());
        _tank = _tankController.CreteTank(_inputController, _mapController.GetPlayerSpawnPoint());
    }

    private void Update()
    {
        _tank.DirectUpdate();
        _inputController.DirectUpdate();
        _enemyController.DirectUpdate();
    } 
}
