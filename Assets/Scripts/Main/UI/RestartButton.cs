using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void RefreshParameters()
    {
        Core.isGameEnded = false;
        Core.score = 0;
    }
}
