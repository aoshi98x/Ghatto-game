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
    [SerializeField] GameObject gameOverUI, humanSprite;

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
        Time.timeScale = 1f;

    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            selectionScript.enabled = true;
            life = 75f;
            noDependencies = false;
            Time.timeScale = 1f;
        }
        if (SceneManager.GetActiveScene().name == "MainScene" && !noDependencies)
        {
            life = 75f;
            CallDependencies();
            noDependencies = true; 
        }

            if (SceneManager.GetActiveScene().name == "MainScene" && noDependencies)
        {
            
            life -= Time.deltaTime;
            selectionScript.enabled = false;

            if (life <= 0)
            {
                healthCount.sprite = null;
                humanSprite.transform.GetChild(2).gameObject.SetActive(false);
                humanSprite.transform.GetChild(1).gameObject.SetActive(false);
                humanSprite.transform.GetChild(0).gameObject.SetActive(true);
                gameOverUI.SetActive(true);
                Time.timeScale = 0f;
            }

            else if(life<=100 && life > 75)
            {
                humanSprite.transform.GetChild(2).gameObject.SetActive(true);
                humanSprite.transform.GetChild(1).gameObject.SetActive(false);
                humanSprite.transform.GetChild(0).gameObject.SetActive(false);
                healthCount.sprite = fullHp;
            }

            else if (life <= 75 && life >= 51)
            {
                healthCount.sprite = thirdQuarterHp;
            }

            else if (life <= 50 && life >= 26)
            {
                humanSprite.transform.GetChild(2).gameObject.SetActive(false);
                humanSprite.transform.GetChild(1).gameObject.SetActive(true);
                humanSprite.transform.GetChild(0).gameObject.SetActive(false);
                healthCount.sprite = halfHp;
            }

            else if (life <= 25 && life >= 11)
            {
                healthCount.sprite = quarterHp;
            }

            else if (life <= 10 && life >= 1)
            {
                humanSprite.transform.GetChild(2).gameObject.SetActive(false);
                humanSprite.transform.GetChild(1).gameObject.SetActive(false);
                humanSprite.transform.GetChild(0).gameObject.SetActive(true);
                healthCount.sprite = tenHp;
            }
        }
        
    }
    void CallDependencies()
    {
        gameOverUI = GameObject.Find("GameOver");
        gameOverUI.SetActive(false);
        humanSprite = GameObject.Find("Humano");
        healthCount = GameObject.Find("Health").GetComponent<Image>();
    }
   

}
