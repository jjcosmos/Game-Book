using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RGameManager : MonoBehaviour
{
    public AudioSource music;
    public bool startPlaying;
    public BeatScroller beatScroller;

    public static RGameManager instance;

    

    public int MaxBossHealth = 100;
    public int currentBossHealth;
    public static int visibleBossHealth;

    public int scorePerNote;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierLevels;
    public static int PlayerHealth;

    public int MaxPlayerHealth;
    public bool startHurt;

    private TextMeshProUGUI PlayerHealthUI;
    private TextMeshProUGUI BossHealthUI;

    [SerializeField] Animator FadeOutAnim;

    void Start()
    {
        

        
        

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        BossHealthUI = GameObject.Find("BossHealth").GetComponent<TextMeshProUGUI>();
        PlayerHealthUI = GameObject.Find("PlayerHealth").GetComponent<TextMeshProUGUI>();
        if (startHurt)
        {
            PlayerHealth = MaxPlayerHealth - 10;
        }
        else { PlayerHealth = MaxPlayerHealth; }
        
        currentBossHealth = MaxBossHealth;
        currentMultiplier = 1;

    }

    public void Reset()
    {
        BossHealthUI = GameObject.Find("BossHealth").GetComponent<TextMeshProUGUI>();
        PlayerHealthUI = GameObject.Find("PlayerHealth").GetComponent<TextMeshProUGUI>();
        PlayerHealth = MaxPlayerHealth;
        currentMultiplier = 1;
    }


    void Update()
    {
        visibleBossHealth = currentBossHealth;
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                beatScroller.hasStarted = true;
                music.Play();
            }
        }

        PlayerHealthUI.text = PlayerHealth.ToString();
        BossHealthUI.text = currentBossHealth.ToString();


        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            RGameManager.instance.EndLevelAndLoadNext();
            Gamemanager.WonBattleFlag = true;
            Debug.Log("WINNNNN");
        }

    }

    public void EndLevelAndLoadNext()
    {
        FadeOutAnim.SetBool("FadeOut", true);
        StartCoroutine(LoadNext());
    }

    private IEnumerator LoadNext()
    {
        float TimePassed = 0;
        while(TimePassed < 3)
        {
            music.volume -= Time.deltaTime * .2f;
            TimePassed += Time.deltaTime;
            yield return null;
        }
        Gamemanager.ReturningFromBattleFlag = true;
        Debug.Log("WINNNNN");
        SceneManager.LoadScene(1);
        
        
    }

    public void NoteHit()
    {
        

        Debug.Log("Hit");
        currentBossHealth -= scorePerNote * currentMultiplier;
    }
    public void NoteMissed()
    {
        Debug.Log("Miss");
        if (PlayerHealth > 0)
        {
            PlayerHealth--;
        }
        if(PlayerHealth <= 0)
        {
            Gamemanager.WonBattleFlag = false;
            RGameManager.instance.EndLevelAndLoadNext();
            
            
        }
    }
}
