using System;
using System.Collections.Generic;
using Sources.Items;
using Sources.PlayerRocket;
using UnityEngine;

namespace Sources.Planets
{
    public class Planet : MonoBehaviour
    {
        [SerializeField] private GravitationField _gravitationField;
        [SerializeField] private ItemsOrbit[] _orbits;
        [SerializeField] private Item[] _defaultItemPrefabs;
        
        public GravitationField GravitationField => _gravitationField;

        public void Init(Rocket playerRocket)
        {
            List<Item> _items = new List<Item>();

            foreach (Item item in _defaultItemPrefabs) 
                _items.Add(Instantiate(item));
            
            InitOrbits(_items.ToArray());
            _gravitationField.AddAttractiveObject(playerRocket.Attractive);
        }

        private void InitOrbits(Item[] orbitItems)
        {
            DistributeItemsOnOrbits(orbitItems);
            foreach (ItemsOrbit orbit in _orbits)
                orbit.Init();
        }

        private void DistributeItemsOnOrbits(Item[] orbitItems)
        {
            if(orbitItems == null)
                return;
            
            int orbit = 0;

            foreach (Item item in orbitItems)
            {
                _orbits[orbit].AddItem(item);
                orbit = (orbit + 1) % _orbits.Length;
            }
        }
    }
}