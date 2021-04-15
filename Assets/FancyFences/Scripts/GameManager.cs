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
            }
        }


        

        if(CheckNumber == 3 && WIN == true)
        {
            //WIN!
            WinScreen.enabled = true;
            PlayeR.SetActive(false);
        }

        CheckpointText.text = "Checkpoint Nummer " + CheckNumber.ToString();


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
        textDisplay.GetComponent<Text>().text = " Verbleibende Zeit " + timeLeft;
        takingAway = false;

    }

}
