using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject BurnableObjs = null;
    [SerializeField] private GameObject FireSpreadsUI = null;
    [SerializeField] private GameObject WinUI = null;
    [SerializeField] private GameObject LoseUI = null;
    [SerializeField] private Text LoseScoreText = null;
    [SerializeField] private Text ScoreText = null;
    private List<float> timers = new List<float>();
    private float FSpreadsUITimer = 0;
    private float UITime = 1;
    [SerializeField]private bool Won = false;
    public bool Tutorial = false;
    public bool IsPaused = false;
    public void SpreadFire()
    {
        FSpreadsUITimer = UITime;
        var burningObjs = new List<BurnableSprite>();
        BurnableObjs.GetComponentsInChildren<BurnableSprite>().Foreach(i => { if (i.Burning) { burningObjs.Add(i); } });
        burningObjs.ForEach(i => i.SpreadFire());
    }
    public void SpreadFire(float delay)
    {
        Debug.Log("s");
        timers.Add(delay);
    }
    private void Start()
    {
        timers = new List<float>();
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            Tutorial = true;
        }
        else
        {
            Tutorial = false;
        }
    }
    private void Update()
    {
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
        var burningObjs = new List<BurnableSprite>();
        BurnableObjs.GetComponentsInChildren<BurnableSprite>().Foreach(i => { if (i.Burning) { burningObjs.Add(i); } });
        if (!burningObjs.Any()) { Win(); }
    }
    private void Win()
    {
        double score = 100;
        var burntdown = new List<GameObject>();
        GameObject.FindGameObjectsWithTag("BurnableSprite").Foreach(i => { if (i.GetComponent<BurnableSprite>().BurntDown) { burntdown.Add(i); } });
        var BBushes = new List<GameObject>();
        var BHouses = new List<GameObject>();
        burntdown.ForEach(i =>
        {
            if (i.GetComponent<HouseTag>() != null) { BHouses.Add(i); }
            else { BBushes.Add(i); }
        });
        BBushes.ForEach(i => score -= 10);
        BHouses.ForEach(i => score -= 40);

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
        Time.timeScale = 0;
    }
    public void UnPause()
    {
        IsPaused = false;
        Time.timeScale = 1;
    }
    public void ReloadCurScene()
    {
        var i = SceneManager.GetActiveScene();
        SceneManager.LoadScene(i.name);
        UnPause();
    }
    private void UpdateTimer()
    {        
        float deltaTime = Time.deltaTime;
        for (int i = 0; i < timers.Count; i++)
        {
            Debug.Log("timer: "+i+" value: "+timers[i]);
            timers[i] -= deltaTime;
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
}