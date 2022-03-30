﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public UnityEngine.UI.Image heart1, heart2, heart3;
    public Sprite heartFull, heartEmtpty;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealthDisplay()
    {
        switch (PlayerHealthController.instance.currentHealth)
        {
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;

                break;

            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmtpty;

                break;

            case 1:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmtpty;
                heart3.sprite = heartEmtpty;

                break;

            case 0:
                heart1.sprite = heartEmtpty;
                heart2.sprite = heartEmtpty;
                heart3.sprite = heartEmtpty;

                break;

            default:
                heart1.sprite = heartEmtpty;
                heart2.sprite = heartEmtpty;
                heart3.sprite = heartEmtpty;

                break;
        }
    }
}
