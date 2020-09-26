using UnityEngine;

namespace MapServices
{
    public class ObjectReference : MonoBehaviour
    {
        [SerializeField] private bool isWire;
        [SerializeField] private Color color = Color.green;
        [SerializeField] private Vector3 size = Vector3.one;

        [SerializeField] public GameObject prefab;

        private void OnDrawGizmos()
        {
            size = prefab != null ? prefab.transform.localScale : Vector3.one;

            var previousColor = Gizmos.color;
            Gizmos.color = color;
            DrawMesh(size);
            Gizmos.color = previousColor;
        }

        private void DrawMesh(Vector3 meshSize)
        {
            if (CanBeDrawn(out var mesh))
            {
                return;
            }

            var objectTransform = transform;
            if (isWire)
            {
                Gizmos.DrawWireMesh(mesh, -1, objectTransform.position, objectTransform.rotation, meshSize);
                return;
            }

            Gizmos.DrawMesh(mesh, -1, objectTransform.position, objectTransform.rotation, meshSize);
        }

        private bool CanBeDrawn(out Mesh mesh)
        {
            if (prefab == null)
            {
                Debug.Log($"'{gameObject.name}': Can't draw mesh, please add Prefab!");
                mesh = null;
                return false;
            }

            mesh = prefab != null ? prefab.GetComponent<MeshFilter>()?.sharedMesh : null;
            if (mesh == null)
            {
                Debug.Log($"'{gameObject.name}': Can't draw mesh, please add MeshFilter component with mesh!");
                return false;
            }

            return true;
        }
    }
}