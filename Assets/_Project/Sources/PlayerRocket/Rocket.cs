using Sources.Items;
using Sources.Planets;
using Sources.Services.Input;
using UnityEngine;

namespace Sources.PlayerRocket
{
    public class Rocket : MonoBehaviour
    {
        [Header("Rocket Components")]
        [SerializeField] private RocketEngine _firstEngine;
        [SerializeField] private RocketEngine _secondEngine;
        [SerializeField] private FuelTank _fuelTank;
        [SerializeField] private Durability _durability;
        [Header("Links")]
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Attractive _attractive;
        [SerializeField] private Wallet _wallet;
        [SerializeField] private DestructionEffects _destructionEffects;

        private IInputService _inputService;
        private PlayerCamera _playerCamera;

        public Vector2 Position => transform.position;
        public FuelTank FuelTank => _fuelTank;
        public Durability Durability => _durability;
        public Attractive Attractive => _attractive;
        public Wallet Wallet => _wallet;

        public void Init(IInputService inputService, PlayerCamera playerCamera)
        {
            _inputService = inputService;
            _playerCamera = playerCamera;

            _durability.Init();
            _fuelTank.Init();
            _firstEngine.Init(_rigidbody, _fuelTank);
            _secondEngine.Init(_rigidbody, _fuelTank);

            Subscribe();
        }

        private void Update()
        {
            if(_durability.IsDestroyed)
                return;

            AimEngines();
        }

        private void OnDestroyed()
        {
            Cleanup();
            
            _firstEngine.TrySetEnabled(false);
            _secondEngine.TrySetEnabled(false);
            
            _destructionEffects.Play();
        }

        private void AimEngines()
        {
            Vector2 engineDirection = (_firstEngine.transform.position - _playerCamera.Camera.ScreenToWorldPoint(_inputService.GetScreenMousePosition())).normalized;

            _firstEngine.SetThrustVector(engineDirection);
            _secondEngine.SetThrustVector(engineDirection);
        }

        private void Subscribe()
        {
            _durability.Destroyed += OnDestroyed;

            _inputService.LeftMouseButtonPressed += OnLeftMouseButtonPressed;
            _inputService.LeftMouseButtonReleased += OnLeftMouseButtonReleased;
            _inputService.RightMouseButtonPressed += OnRightMouseButtonPressed;
            _inputService.RightMouseButtonReleased += OnRightMouseButtonReleased;
        }

        private void Cleanup()
        {
            _durability.Destroyed -= OnDestroyed;
            
            _inputService.LeftMouseButtonPressed -= OnLeftMouseButtonPressed;
            _inputService.LeftMouseButtonReleased -= OnLeftMouseButtonReleased;
            _inputService.RightMouseButtonPressed -= OnRightMouseButtonPressed;
            _inputService.RightMouseButtonReleased -= OnRightMouseButtonReleased;
        }

        private void OnLeftMouseButtonPressed() => 
            _firstEngine.TrySetEnabled(true);

        private void OnLeftMouseButtonReleased() => 
            _firstEngine.TrySetEnabled(false);

        private void OnRightMouseButtonPressed() => 
            _secondEngine.TrySetEnabled(true);

        private void OnRightMouseButtonReleased() => 
            _secondEngine.TrySetEnabled(false);
    }
}