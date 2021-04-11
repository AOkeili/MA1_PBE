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

  /*  public override State Tick(EnemyManager enemyManager, Enemy enemy, EnemyAnimationManager enemyAnimationManager)
    {
        if (enemyManager.isPerformingAction) return attackStanceState;
        if (currentAttack != null)
        {
            if (enemyManager.distanceFromTarget < currentAttack.minimumDistanceNeededToAttack)
            {
                return this;
            }
            else if (enemyManager.distanceFromTarget < currentAttack.maximumDistanceNeededToAttack)
            {
                if (enemyManager.currentCooldown <= 0 && enemyManager.isPerformingAction == false)
                {
                    enemyAnimationManager.animator.SetFloat("ForwardVelocity", 0, 0.1f, Time.fixedDeltaTime);
                    enemyAnimationManager.animator.SetFloat("LateralVelocity", 0, 0.1f, Time.fixedDeltaTime);
                    enemyAnimationManager.PlayTargetAnimation(currentAttack.actionAnimation, true);
                    enemyManager.isPerformingAction = true;
                    fireRates = currentAttack.rates;
                    AttackTarget(enemyManager, enemyAnimationManager);
                    enemyManager.currentCooldown = currentAttack.cooldown;
                    currentAttack = null;
                    return attackStanceState;
                }
            }
        }
        else
        {
            GetNewAttack(enemyManager);

        }
        return attackStanceState;
    }

    */
    #region Attack

   /* void AttackTarget()
    {
       
        if (bulletLeft > 0) Shoot();
        else { 
            ProcessReload();
            Reload();
        }
        
        if (shootTimer < fireRates)
            shootTimer += Time.deltaTime;

    }*/
    /*
    void GetNewAttack(EnemyManager enemyManager)
    {

        enemyManager.distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
        for (int i = 0; i < enemyAttacks.Length; i++)
        {
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];
            if (enemyManager.distanceFromTarget <= enemyAttackAction.maximumDistanceNeededToAttack &&
                enemyManager.distanceFromTarget >= enemyAttackAction.minimumDistanceNeededToAttack)
            {

                if (currentAttack != null) return;
                currentAttack = enemyAttackAction;
            }
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {
        /*   if (cam == null)
           {
               Debug.Log("No camera referenced");
               this.enabled = false;
           }*/
        bulletLeft = bulletPerMag;
        audioSource = GetComponent<AudioSource>();
    }
    /*
        // Update is called once per frame
        void Update()
        {
            if (false)//Input.GetButtonDown("Fire1"))
            {
                if (bulletLeft > 0) Shoot();
                else ProcessReload();
            }

            if (shootTimer < fireRates)
                shootTimer += Time.deltaTime;
        }

        void FixedUpdate()
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        }*/

    public void Shoot()
    {

       
        RaycastHit hit;
        if (Physics.Raycast(enemyEyes.transform.position, enemyEyes.transform.forward, out hit, currentAttack.maximumDistanceNeededToAttack, mask))
        {
            Debug.Log("Target Object : " + hit.collider.name);
            if (hit.collider.CompareTag("Player"))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                Debug.Log("Boum : " + currentAttack.attackDamage);

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

    void ProcessReload(EnemyAnimationManager enemyAnimationManager)
    {
        enemyAnimationManager.animator.CrossFadeInFixedTime("Reload", 0.01f);
    }

    void Reload()
    {
        bulletLeft = 30;
    }

    #endregion
}
