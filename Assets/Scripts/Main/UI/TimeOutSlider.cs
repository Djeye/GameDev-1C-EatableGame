using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeOutSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private float timeOutSeconds;

    private float currentTime;
    void Start()
    {
        timeOutSeconds = Core.timeOut;
        SetupMaxTime();
        Core.addScoreEvent += SetupMaxTime;
        Core.removeLiveEvent += SetupMaxTime;
    }

    void FixedUpdate()
    {
        if (Core.isGameEnded) return;

        currentTime -= Time.fixedDeltaTime;
        slider.value = currentTime / timeOutSeconds;

        if (currentTime < 0) Core.RemoveLive();
    }

    private void SetupMaxTime()
    {
        currentTime = timeOutSeconds;
    }

    private void OnDisable()
    {
        Core.addScoreEvent -= SetupMaxTime;
        Core.removeLiveEvent -= SetupMaxTime;
    }
}
