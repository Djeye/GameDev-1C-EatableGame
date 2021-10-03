using UnityEngine;
using UnityEngine.UI;

public class TimeOutSlider : MonoBehaviour
{
    private Slider _slider;
    private float _timeOutSeconds;
    private float _currentTime;

    void Start()
    {
        _slider = GetComponent<Slider>();
        _timeOutSeconds = Core.timeOut;
        SetupMaxTime();

        Core.AddScoreEvent += SetupMaxTime;
        Core.RemoveLiveEvent += SetupMaxTime;
    }

    void FixedUpdate()
    {
        if (Core.isGameEnded) return;

        _currentTime -= Time.fixedDeltaTime;
        _slider.value = _currentTime / _timeOutSeconds;

        if (_currentTime < 0) Core.RemoveLive();
    }

    private void SetupMaxTime()
    {
        _currentTime = _timeOutSeconds;
    }

    private void OnDisable()
    {
        Core.AddScoreEvent -= SetupMaxTime;
        Core.RemoveLiveEvent -= SetupMaxTime;
    }
}
