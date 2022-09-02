using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseUI = null;
    [SerializeField] private GameObject BurnableObjs = null;
    [SerializeField] private GameObject FireSpreadsUI = null;
    [SerializeField] private GameObject WinUI = null;
    [SerializeField] private GameObject LoseUI = null;
    [SerializeField] private Text LoseScoreText = null;
    [SerializeField] private Text ScoreText = null;
    private List<float> timers = new List<float>();
    private float FSpreadsUITimer = 0;
    private float UITime = 1;
    [SerializeField] private bool Won = false;
    [SerializeField]
    private Dictionary<BurnableObject, int> ScoreMinusPoints
        = new Dictionary<BurnableObject, int>() { { BurnableObject.Bush, 10 }, { BurnableObject.House, 40 } };
    [SerializeField] public bool Tutorial = false;
    [SerializeField] public bool IsPaused = false;
    public void SpreadFire()
    {
        FSpreadsUITimer = UITime;
        var burningObjs = new List<BurnableSprite>();
        BurnableObjs.GetComponentsInChildren<BurnableSprite>().Foreach(i => { if (i.Burning) { burningObjs.Add(i); } });
        burningObjs.ForEach(i => i.SpreadFire());
    }
    public void SpreadFire(float delay)
    {
        timers.Add(delay);
    }
    private void Start()
    {
        Time.timeScale = 1f;
        timers = new List<float>();
        Tutorial = SceneManager.GetActiveScene().name == "Tutorial";
        IsPaused = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (IsPaused) { UnPause(); }
            else { PauseGame(); }
        }
        if (!Won)
        {
            UpdateTimer();
            CheckWinning();
            UpdateUI();
        }
    }
    private void UpdateUI()
    {
        if (FSpreadsUITimer > 0)
        {
            FireSpreadsUI.SetActive(true);
            FSpreadsUITimer -= Time.deltaTime;
        }
        else
        {
            FireSpreadsUI.SetActive(false);
        }
    }
    private void CheckWinning()
    {
        if (BurnableSprite.BurningFinished())
        {
            Win();
        }
    }
    private void Win()
    {
        int score = 100;
        var burntDown = BurnableSprite.BurntObjects;
        foreach (var keyval in burntDown)
        {
            score -= ScoreMinusPoints[keyval.Key] * keyval.Value;
        }
        if (score > 0)
        {
            ScoreText.text = "Score: " + score;
            WinUI.SetActive(true);
            Won = true;
            Pause();
        }
        else
        {
            LoseScoreText.text = "Score: " + score;
            LoseUI.SetActive(true);
            Pause();
        }
    }
    public void Pause()
    {
        IsPaused = true;
        Time.timeScale = 0f;
    }
    public void UnPause()
    {
        IsPaused = false;
        Time.timeScale = 1f;
    }
    public void ReloadCurScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private static void ResetTimeScale() => Time.timeScale = 1f;
    private void UpdateTimer()
    {
        for (int i = 0; i < timers.Count; i++)
        {
            timers[i] -= Time.deltaTime;
        }
        int count = timers.Count;
        for (int i = 0; i < count; i++)
        {
            int ind = count - i - 1;
            if (timers[ind] <= 0)
            {
                SpreadFire();
                timers.RemoveAt(ind);
            }
        }
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        UnPause();
    }
    public void LoadNextScene()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(i + 1);
        UnPause();
    }
    public void PauseGame()
    {
        Pause();
        PauseUI.SetActive(true);
    }
    public void UnPauseGame()
    {
        UnPause();
        PauseUI.SetActive(false);
    }
    public void Restart()
    {
        // UnPauseGame();
        ReloadCurScene();
    }
}