using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int CheckNumber;

    public bool Check = false;

    public bool Goal = false;

    public bool WIN = false;

    public Canvas WinScreen;
    public GameObject PlayeR;

    public Text CheckpointText;

    public GameObject Checkpoint1;
    public GameObject Checkpoint2;
    public GameObject Checkpoint3;

    public GameObject textDisplay;

    public int timeLeft = 50;

    public bool takingAway = false;

    public bool PlayerWon = false;
    public bool noTimeLeft = false;

    public bool InEndScreen = false;

    public GameObject WinTrigger;

    public Canvas PauseMenu;


    void Update()
    {
        if(Check == true)
        {
            Check = false;
            CheckNumber += 1;
            Checkpoint1.SetActive(false);

            if (CheckNumber == 2)
            {
                Checkpoint2.SetActive(false);
                
            }
            if (CheckNumber == 3)
            {
                Checkpoint3.SetActive(false);
                Checkpoint1.SetActive(true);
            }

            if(CheckNumber == 4)
            {
                Checkpoint1.SetActive(false);
                Checkpoint2.SetActive(true);
            }
            if(CheckNumber == 5)
            {
                Checkpoint2.SetActive(false);
                Checkpoint3.SetActive(true);
            }
            if(CheckNumber == 6)
            {
                Checkpoint1.SetActive(false);
                Checkpoint2.SetActive(false);
                Checkpoint3.SetActive(false);
                WinTrigger.SetActive(true);
            }
        }


        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            PauseMenu.enabled = true;
        }

        if( WIN == true)
        {
            //WIN!
            WinScreen.enabled = true;
            PlayeR.SetActive(false);
        }

        CheckpointText.text = "Point " + CheckNumber.ToString();


        if (takingAway == false && timeLeft > 0 && PlayerWon == false)
        {
            StartCoroutine(TimerTake());
        }

    }

    IEnumerator TimerTake()
    {

        takingAway = true;
        yield return new WaitForSeconds(1);
        timeLeft -= 1;
        textDisplay.GetComponent<Text>().text = " Time Left " + timeLeft;
        takingAway = false;

    }

    public void ExitPause()
    {
        PauseMenu.enabled = false;
        Time.timeScale = 1f;
    }

}
