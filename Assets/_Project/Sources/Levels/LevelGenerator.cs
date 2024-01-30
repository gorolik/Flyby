using Sources.Planets;
using Sources.PlayerRocket;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sources.Levels
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private Planet _planetPrefab;
        [SerializeField] private Transform _parent;

        public void Generate()
        {

        }
    }
}