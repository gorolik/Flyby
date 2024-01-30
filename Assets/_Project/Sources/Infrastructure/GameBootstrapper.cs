using System.Collections.Generic;
using Sources.Infrastructure.DI;
using Sources.Services.Input;
using UnityEngine;

namespace Sources.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private AllServices _services;
        private List<IUpdatable> _updatables = new List<IUpdatable>();

        private void Awake()
        {
            _services = AllServices.Container;

            RegistryServices();

            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            foreach (IUpdatable updatable in _updatables)
                updatable.Update();
        }

        private void RegistryServices() =>
            RegistryInputService();

        private void RegistryInputService()
        {
            IInputService inputService = new InputService();
            _services.RegisterSingle(inputService);

            _updatables.Add(inputService);
        }
    }
}