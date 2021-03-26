using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public PlayerWeapon weapon;
    public GameObject hitParticules;

    [SerializeField] Camera cam;
    [SerializeField] LayerMask mask;
    [SerializeField] float fireRates = 0.1f;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem fireShoot;
    [SerializeField] AudioClip shootSound;

    PlayerController controls;
    AudioSource audioSource;
    int bulletPerMag = 1;
    int bulletLeft;
    float shootTimer;

    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            Debug.Log("No camera referenced");
            this.enabled = false;
        }
        controls = new PlayerController();
        controls.Gameplay.Fire.performed += ctx => {
            if (bulletLeft > 0) Shoot();
            else ProcessReload();
        };
        controls.Gameplay.Fire.Enable();
        bulletLeft = bulletPerMag;
        audioSource = GetComponent<AudioSource>();
    }

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
    }

    void Shoot()
    {
        if (shootTimer < fireRates || bulletLeft <= 0) return;

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask))
        {
            Debug.Log("Target Object : " + hit.collider.name);
            if (hit.collider.CompareTag("Enemy"))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                enemy.TakeDamage(weapon.damage);
            }
            GameObject hitParticleEffect = Instantiate(hitParticules, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            Destroy(hitParticleEffect, 1f);
        }
        bulletLeft--;
        fireShoot.Play();
        PlayShootSound();
        animator.CrossFadeInFixedTime("Fire", 0.1f);
        shootTimer = 0f;
    }

    void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSound);
    }

    void ProcessReload()
    {
        animator.CrossFadeInFixedTime("Reload", 0.01f);
    }

    public void Reload()
    {
        bulletLeft = 30;
    }
}
