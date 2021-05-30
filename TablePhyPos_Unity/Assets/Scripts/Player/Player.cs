using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    const string AUDIO_BGM = "bgm";
    const string AUDIO_FIRESFX = "blazeSFX";

    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth = 0;
    [SerializeField] bool _isDead = false;
    [SerializeField] Text healthData;
    [SerializeField] Behaviour[] componentToDisable;
    [SerializeField] Light cockpitLight;
    [SerializeField] Image[] blackScreens;

    PlayerController inputActions;

    bool[] componentWasEnable;

    void Start()
    {
        componentWasEnable = new bool[componentToDisable.Length];
        for (int i = 0; i < componentWasEnable.Length; i++)
        {
            componentWasEnable[i] = componentToDisable[i].enabled;
        }
        inputActions = new PlayerController();
        inputActions.Gameplay.TestTakeDamage.started += ctx => { TakeDamage(10); };
        inputActions.Gameplay.TestTakeDamage.Enable();
        for(int i = 0; i < blackScreens.Length; i++) blackScreens[i].canvasRenderer.SetAlpha(0f);
        setDefault();

        FindObjectOfType<AudioManager>().Play(AUDIO_BGM);
        FindObjectOfType<AudioManager>().Play(AUDIO_FIRESFX);
    }


    void Update()
    {
        if (_isDead)
        {
            cockpitLight.color = Color.Lerp(cockpitLight.color, Color.red, 0.02f);
        }    
    }

    public void TakeDamage(int damage)
    {
        if (_isDead) return;
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        float healthRatio = ((float)currentHealth / (float)maxHealth) * 100;
        healthData.text = "Shield : " + healthRatio + "%";
        if (currentHealth == 0)
        {
            for (int i = 0; i < blackScreens.Length; i++) blackScreens[i].CrossFadeAlpha(1, 1, false);
            Die();
        }
        else {
            SensorManager.Instance().SendHitSensation();
        };
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
        Destroy(GameObject.Find("FloorVFX").gameObject);
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
