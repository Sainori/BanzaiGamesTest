using UnityEngine;

namespace MapServices
{
    public class ObjectReference : MonoBehaviour
    {
        [SerializeField] private bool isWire;
        [SerializeField] private Color color = Color.green;
        [SerializeField] private Vector3 size = Vector3.one;

        [SerializeField] public GameObject prefab;
        private MeshFilter _meshFilter;

        private void OnDrawGizmos()
        {
            _meshFilter = prefab != null ? prefab.GetComponent<MeshFilter>() : null;
            size = prefab != null ? prefab.transform.localScale : Vector3.one;

            var previousColor = Gizmos.color;
            Gizmos.color = color;
            DrawMesh(size);
            Gizmos.color = previousColor;
        }

        private void DrawMesh(Vector3 meshSize)
        {
            if (!CanBeDrawn())
            {
                return;
            }

            var mesh = _meshFilter.sharedMesh;
            var objectTransform = transform;
            if (isWire)
            {
                Gizmos.DrawWireMesh(mesh, -1, objectTransform.position, objectTransform.rotation, meshSize);
                return;
            }

            Gizmos.DrawMesh(mesh, -1, objectTransform.position, objectTransform.rotation, meshSize);
        }

        private bool CanBeDrawn()
        {
            if (prefab == null)
            {
                Debug.LogError($"'{gameObject.name}': Can't draw mesh, please add Prefab!");
                return false;
            }

            if (_meshFilter == null)
            {
                Debug.LogError($"'{gameObject.name}': Can't draw mesh, please add MeshFilter component with mesh!");
                return false;
            }

            return true;
        }
    }
}