﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isGem, isHeal;

    private bool isCollected;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (isCollected) return;

        if (isGem)
        {
            LevelManager.instance.gemsCollected++;
            isCollected = true;

            Destroy(gameObject);

            UIController.instance.UpdateGemCount();
        }

        if (isHeal)
        {
            if (PlayerHealthController.instance.currentHealth >= PlayerHealthController.instance.maxHealth) return;
            PlayerHealthController.instance.HealPlayer();
            isCollected = true;

            Destroy(gameObject);
        }
    }
}
