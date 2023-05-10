using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timeElapsed;

    void Update()
    {
        // Increment the timeElapsed variable by the time passed since the last frame
        timeElapsed += Time.deltaTime;

        // Format the timeElapsed as minutes and seconds
        int minutes = (int)timeElapsed / 60;
        int seconds = (int)timeElapsed % 60;

        // Update the timerText UI element with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}