using System.Collections.Generic;
using UnityEngine;

namespace MapServices
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private List<ObjectReference> objectReferences = new List<ObjectReference>();
        [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();

        public void BuildByReferences(Transform mapTransform)
        {
            foreach (var reference in objectReferences)
            {
                var referenceTransform = reference.transform;
                gameObjects.Add(Instantiate(reference.prefab, referenceTransform.position, referenceTransform.rotation, mapTransform));
            }
        }
    }
}