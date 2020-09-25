using System;
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

    private Tank _tank;

    private void Awake()
    {
        _mapController = gameObject.GetComponent<IMapController>();
        _tankController = gameObject.GetComponent<ITankController>();
        _inputController = gameObject.GetComponent<IInputController>();
    }

    private void Start()
    {
        _mapController.CreateMap();
        _tank = _tankController.CreteTank(_inputController);
    }

    private void Update()
    {
        _tank.DirectUpdate();
        _inputController.DirectUpdate();
    }
}
