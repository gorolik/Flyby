using Sources.Infrastructure.DI;
using Sources.Planets;
using Sources.PlayerRocket;
using Sources.Services.Input;
using Sources.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.Levels
{
    public class Level : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private Rocket _rocketPrefab;
        [SerializeField] private PlayerCamera _cameraPrefab;
        [SerializeField] private PlayerHud _hudPrefab;
        [Header("Level")] 
        [SerializeField] private SmoothTargetFollower _background;
        [SerializeField] private RadiationBounds _radiationBounds;
        [SerializeField] private Planet[] _planets;

        private Rocket _playerRocket;
        
        private void Start()
        {
            AllServices services = AllServices.Container;

            InitPlayer(services.Single<IInputService>());
            InitPlanets(_playerRocket);

            _radiationBounds.Init(_playerRocket);
            _background.SetTarget(_playerRocket.transform);
        }

        private void OnDestroy() => 
            _playerRocket.Durability.Destroyed -= OnPlayerRocketDestroyed;

        private void InitPlayer(IInputService inputService)
        {
            _playerRocket = Instantiate(_rocketPrefab);
            PlayerCamera playerCamera = Instantiate(_cameraPrefab);
            PlayerHud hud = Instantiate(_hudPrefab);
            
            _playerRocket.Init(inputService, playerCamera);
            playerCamera.Init(_playerRocket.transform);
            hud.Init(_playerRocket);
            
            _playerRocket.Durability.Destroyed += OnPlayerRocketDestroyed;
        }

        private void InitPlanets(Rocket playerRocket)
        {
            foreach (Planet planet in _planets)
                planet.Init(playerRocket);
        }

        private void OnPlayerRocketDestroyed() => 
            Invoke(nameof(ReloadLevel), 3.5f);

        private void ReloadLevel() => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}