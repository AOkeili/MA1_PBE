using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth = 0;
    [SerializeField] bool _isDead = false;
    [SerializeField] HealthBar bar;
    [SerializeField] Behaviour[] componentToDisable;

    bool[] componentWasEnable;

    void Start()
    {
        componentWasEnable = new bool[componentToDisable.Length];
        for (int i = 0; i < componentWasEnable.Length; i++)
        {
            componentWasEnable[i] = componentToDisable[i].enabled;
        }
        setDefault();
    }


    public void TakeDamage(int damage)
    {
        if (_isDead) return;
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        
        Debug.Log(transform.name + " - " + currentHealth);
        bar.setHealthValue((float) currentHealth / (float) maxHealth);
        if (currentHealth == 0)
        {
            Animator animator = GetComponent<Animator>();
            animator.SetTrigger("Die");
        }
    }
    public bool isDead()
    {
        return _isDead;
    }

    public void Die()
    {
        _isDead = true;
        for (int i = 0; i < componentToDisable.Length; i++)
        {
            componentToDisable[i].enabled = false;
        }
        Collider col = GetComponent<Collider>();
        if (col != null) col.enabled = true;
    }

    public void setDefault()
    {
        _isDead = false;
        currentHealth = maxHealth;

        for (int i = 0; i < componentToDisable.Length; i++)
        {
            componentToDisable[i].enabled = componentWasEnable[i];
        }

        Collider col = GetComponent<Collider>();
        if (col != null) col.enabled = true;
    }
}
