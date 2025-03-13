using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject.SpaceFighter;

public class BulletsDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private PlayerController _player;

    public void Init(PlayerController player)
    {
        _player = player;

        _player.Shoted += OnBulletsChanged;
        _player.Reloaded += OnBulletsChanged;
        _player.WeaponChanged += OnBulletsChanged;
    }

    private void OnDestroy()
    {
        _player.Shoted -= OnBulletsChanged;
        _player.Reloaded -= OnBulletsChanged;
        _player.WeaponChanged -= OnBulletsChanged;
    }

    private void OnBulletsChanged()
    {
        if (_player.CurrentWeapon != null)
            _text.text = $"{_player.CurrentWeapon.BulletsLeft}/{_player.CurrentWeapon.Data.ClipCapacity * _player.ClipsLeft}";
        else
            _text.text = "no weapon";
    }
}
