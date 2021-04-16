using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    ///public AttackStanceState attackStanceState;

   // public EnemyAttackAction[] enemyAttacks;
    public EnemyAttackAction currentAttack;

    public PlayerWeapon weapon;
    public GameObject hitParticules;
    public GameObject enemyEyes;

    [SerializeField] LayerMask mask;
    [SerializeField] float fireRates = 0.1f;
    [SerializeField] ParticleSystem fireShoot;
    [SerializeField] AudioClip shootSound;

    AudioSource audioSource;
    int bulletPerMag = 1;
    int bulletLeft;
    float shootTimer;

    // Start is called before the first frame update
    void Start()
    {
        bulletLeft = bulletPerMag;
        audioSource = GetComponent<AudioSource>();
    }
    

    public void Shoot()
    {  
        RaycastHit hit;
        if (Physics.Raycast(enemyEyes.transform.position, enemyEyes.transform.forward, out hit, currentAttack.maximumDistanceNeededToAttack, mask))
        {
           Debug.Log("Target Object : " + hit.collider.name);
            if (hit.collider.CompareTag("Player"))
            {
                Player player= hit.collider.GetComponent<Player>();
                if (player.isDead()) return;
                player.TakeDamage(weapon.damage);

                //enemy.TakeDamage(weapon.damage);
            }
            GameObject hitParticleEffect = Instantiate(hitParticules, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            Destroy(hitParticleEffect, 1f);
        }
        fireShoot.Play();
        PlayShootSound();
    }

    void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSound);
    }

}
