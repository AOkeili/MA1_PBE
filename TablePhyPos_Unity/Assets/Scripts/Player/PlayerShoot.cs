using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    const string AUDIO_SHOOTSFX = "shootSFX";

    public PlayerWeapon weapon;
    public GameObject hitParticules;

    [SerializeField] Transform shootTarget;
    [SerializeField] LayerMask mask;
    [SerializeField] float fireRates = 0.1f;
    [SerializeField] Animator animator;
    [SerializeField] Text bulletCount;

    [SerializeField] GameObject projectile;

    PlayerController controls;
    int bulletPerMag = 30;
    int bulletLeft;
    float shootTimer;

    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerController();
        controls.Gameplay.Fire.performed += ctx => {
            if (bulletLeft > 0) Shoot();
            else ProcessReload();
            bulletCount.text = "Bullet : " + bulletLeft;

        };
        controls.Gameplay.Fire.Enable();
        bulletLeft = bulletPerMag;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootTimer < fireRates)
            shootTimer += Time.deltaTime;
    }

    void Shoot()
    {
        if (shootTimer < fireRates || bulletLeft <= 0) return;

        GameObject tmpProjectile = Instantiate(projectile, shootTarget.position, Quaternion.LookRotation(shootTarget.forward));

        RaycastHit hit;
        if (Physics.Raycast(shootTarget.position, shootTarget.forward, out hit, weapon.range, mask))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                enemy.TakeDamage(weapon.damage);
            }
            GameObject hitParticleEffect = Instantiate(hitParticules, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            Destroy(hitParticleEffect, 1f);
        }

        bulletLeft--;
        FindObjectOfType<AudioManager>().Play(AUDIO_SHOOTSFX);
        animator.CrossFadeInFixedTime("Fire", 0.1f);
        shootTimer = 0f;
    }

    void ProcessReload()
    {
        animator.CrossFadeInFixedTime("Reload", 0.01f);
    }

    public void Reload()
    {
        bulletLeft = 30;
        bulletCount.text = "Bullet : " + bulletLeft;

    }
}
