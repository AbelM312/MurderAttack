using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{

    public int numberOfCrows;

    ScoreCounter scoreCounter;
    
    // Start is called before the first frame update
    void Start()
    {

        scoreCounter = new ScoreCounter();

        numberOfCrows = 10;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (numberOfCrows == 0)
        {

            YouWin();

        }

        if (scoreCounter.score == 0)
        {

            GameOver();

        }
        
    }

    void YouWin()
    {



    }

    void GameOver()
    {



    }
}
