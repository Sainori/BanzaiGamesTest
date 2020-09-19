using UnityEngine;

public class StartupController : MonoBehaviour
{
    [SerializeField] private MapController.MapController mapController;
    
    private object _tank;
    private object _map;

    /// <summary>
    /// Main goal of startup controller -> create all services
    /// </summary>
    // Start is called before the first frame update
    private void Start()
    {
        _map = mapController.CreateMap();
        // _tank = new TankFactory().CreateTank();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // _tank.Update();
    }
}
