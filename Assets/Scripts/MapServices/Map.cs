using System.Collections.Generic;
using UnityEngine;

namespace MapServices
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private List<ObjectReference> objectReferences = new List<ObjectReference>();
        [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();

        /// <summary>
        /// Нужно создать карту, на navMesh пока забить
        /// Потом сделать точки спавна монстров и танка
        /// </summary>
        public void BuildByReferences()
        {
            foreach (var reference in objectReferences)
            {
                gameObjects.Add(Instantiate(reference.prefab, reference.transform.position, transform.rotation, transform));
            }
        }
    }
}