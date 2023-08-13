using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class InputManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private GameManager gameManager;

    private bool isTouching = false;


    void Update()
    {
        ReadTouch();
    }

    private void ReadTouch()
    {
        int touchCount = Input.touchCount;
        isTouching = false;
        if (touchCount > 0)
        {
            for (int i = 0; i < touchCount; i++)
            {
                if (Input.touches[i].phase == TouchPhase.Began || Input.touches[i].phase == TouchPhase.Stationary || Input.touches[i].phase == TouchPhase.Moved)
                {
                    isTouching = true;
                }

                if (isTouching == true)
                {
                    PlayerTapped(Input.touches[i]);
                }

                if (Input.touches[i].phase == TouchPhase.Ended)
                {
                    Debug.Log("Touch Ended");
                }
            }
        }
    }


    private void PlayerTapped(Touch currentTouch)
    {
 
            Vector2 forceToApply;           
            
            Resolution resolution = Screen.currentResolution;
            float middleX = resolution.width / 2f;
            if (currentTouch.position.x >= middleX)
            {
                forceToApply = (Vector2.right * 150f);
            }
            else
            {
                forceToApply = (Vector2.left * 150f);
            }
            gameManager.playerRigidBody.AddForce(forceToApply);       
    }
}