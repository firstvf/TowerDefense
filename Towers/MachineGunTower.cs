using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunTower : Tower
{
    [SerializeField] private AudioClip _shootSound;
    protected override int Damage { get; set; }
    protected override int AttackRadius { get; set; }
    protected override float AttackSpeed { get; set; }
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Damage = 5;
        AttackRadius = 6;
        AttackSpeed = 0.4f;
    }

    protected override void ShootSound()
    {
        _audioSource.PlayOneShot(_shootSound,0.05f);
    }
}