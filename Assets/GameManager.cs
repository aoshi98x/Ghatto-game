using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    CharacterSelection selectionScript;

    bool noDependencies;
    public float life;
    [SerializeField] Image healthCount; 
    [SerializeField] Sprite tenHp, quarterHp, halfHp, thirdQuarterHp, fullHp;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        selectionScript = GetComponent<CharacterSelection>();

    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainScene" && !noDependencies)
        {
            life = 75f;
            CallDependencies();
            noDependencies = true; 
        }

            if (SceneManager.GetActiveScene().name == "MainScene")
        {
            
            life -= Time.deltaTime;
            selectionScript.enabled = false;

            if (life <= 0)
            {
                healthCount.sprite = null;
            }

            else if(life<=100 && life > 75)
            {
                healthCount.sprite = fullHp;
            }

            else if (life <= 75 && life >= 51)
            {
                healthCount.sprite = thirdQuarterHp;
            }

            else if (life <= 50 && life >= 26)
            {
                healthCount.sprite = halfHp;
            }

            else if (life <= 25 && life >= 11)
            {
                healthCount.sprite = quarterHp;
            }

            else if (life <= 10 && life >= 1)
            {
                healthCount.sprite = tenHp;
            }
        }
        
    }
    void CallDependencies()
    {
        healthCount = GameObject.Find("Health").GetComponent<Image>();
    }
   
}
