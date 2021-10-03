using UnityEngine;
using TMPro;

public class EndPanelManager : MonoBehaviour
{
    [SerializeField] GameObject endPanel;
    [SerializeField] TextMeshProUGUI endPanelscoreText;

    void Start()
    {
        Core.EndGameEvent += EndGameProcess;
    }

    private void EndGameProcess()
    {
        endPanel.SetActive(true);
        endPanelscoreText.text = Core.score.ToString();
    }

    private void OnDisable()
    {
        Core.EndGameEvent -= EndGameProcess;
    }
}
