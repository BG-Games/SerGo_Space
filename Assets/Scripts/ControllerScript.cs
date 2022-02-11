using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject GameUI;
    public static int score = 0;
    public UnityEngine.UI.Text scoreLable;
    public UnityEngine.UI.Text scoreLableMenu;
    public UnityEngine.UI.Button startBtn;
    public static bool isStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        GameUI.SetActive(false);
        startBtn.onClick.AddListener(delegate
        {
            GameUI.SetActive(true);
            menu.SetActive(false);
            isStarted = true;
            score = 0;

        });
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted == false && PlayerScript.alive == false)
        {
            StartCoroutine(waiter());


        }
        scoreLableMenu.text = "Last score: " + score;
        scoreLable.text = "Score: " + score;
    }
    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(3);
        menu.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameUI.SetActive(false);
    }
    }
