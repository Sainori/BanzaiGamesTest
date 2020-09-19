using System;
using MapServices;
using MapServices.Interfaces;
using TankServices;
using TankServices.Interfaces;
using UnityEngine;

public class StartupController : MonoBehaviour
{
    private IMapController _mapController;
    private ITankController _tankController;
    private Tank _tank;

    private void Start()
    {
        _mapController = transform.GetComponent<MapController>();
        _tankController = transform.GetComponent<TankController>();

        _tank = _tankController.CreteTank();
        _mapController.CreateMap();
    }

    private void FixedUpdate()
    {
        _tank.Update();
    }
}
