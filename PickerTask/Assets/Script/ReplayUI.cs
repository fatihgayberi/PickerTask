﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReplayUI : MonoBehaviour
{
    [SerializeField] Button replayBtn;

    // Start is called before the first frame update
    void Start()
    {
        replayBtn.onClick.AddListener(TaskOnTouchReplay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnTouchReplay()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
