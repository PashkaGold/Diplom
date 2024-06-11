using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerSwitchScen : MonoBehaviour
{
    // Тривалість таймера в секундах
    public float timerDuration = 10f;

    // Індекс сцени для завантаження
    public int sceneToLoadIndex;

    // UI елемент для відображення таймера
    public TMP_Text  timerText;

    private float timeRemaining;

    void Start()
    {
        // Ініціалізація залишкового часу
        timeRemaining = timerDuration;
    }

    void Update()
    {
        // Відлік часу
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            // Завантаження нової сцени, коли таймер закінчився
            SceneManager.LoadScene(sceneToLoadIndex);
        }
    }

    void UpdateTimerUI()
    {
        // Оновлення UI таймера
        if (timerText != null)
        {
            timerText.text = Mathf.Ceil(timeRemaining).ToString();
        }
    }
}
