using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private PlayerController _playerPrefab;
    [SerializeField] private Weapon _startWeaponPrefab;
    [SerializeField] private BulletsDisplay _bulletsDisplay;
    [SerializeField] private MainCameraController _mainCameraController;

    private void Start()
    {
        Weapon startWeapon = Instantiate(_startWeaponPrefab);
        PlayerController player = Instantiate(_playerPrefab);
        _mainCameraController.Init(player.transform);
        _bulletsDisplay.Init(player);
        player.Init(startWeapon, new BulletFactory());
    }
}