﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    const string AUDIO_SHOOTSFX = "shootSFX";

    public EnemyAttackAction currentAttack;

    public PlayerWeapon weapon;
    public GameObject hitParticules;
    public GameObject enemyEyes;

    [SerializeField] LayerMask mask;
    [SerializeField] float fireRates = 0.1f;
    [SerializeField] ParticleSystem fireShoot;
    [SerializeField] GameObject projectile;

    public void Shoot()
    {
        RaycastHit hit;
        GameObject tmpProjectile = Instantiate(projectile, enemyEyes.transform.position, Quaternion.LookRotation(enemyEyes.transform.forward));
        if (Physics.Raycast(enemyEyes.transform.position, enemyEyes.transform.forward, out hit, currentAttack.maximumDistanceNeededToAttack, mask))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Player player = hit.collider.GetComponent<Player>();
                if (player.isDead()) return;
                player.TakeDamage(weapon.damage);

            }
            GameObject hitParticleEffect = Instantiate(hitParticules, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            Destroy(hitParticleEffect, 1f);
        }
        fireShoot.Play();
        FindObjectOfType<AudioManager>().Play(AUDIO_SHOOTSFX);

    }
}