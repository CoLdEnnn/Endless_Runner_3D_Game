using UnityEngine;
using Sydewa;

public class DayNightSwitcher : MonoBehaviour
{
    public LightingManager lightingManager;

    [Header("Time Settings")]
    public float dayTime = 11.5f;
    public float nightTime = 20.5f;

    [Header("Transition Settings")]
    public float transitionSpeed = 0.5f;

    bool goingToNight = false;

    void Start()
    {
        // Отключаем auto cycle у ассета
        lightingManager.IsDayCycleOn = false;

        // Стартуем днем
        lightingManager.TimeOfDay = dayTime;
    }

    void Update()
    {
        // Плавный переход к ночи
        if (goingToNight)
        {
            lightingManager.TimeOfDay = Mathf.Lerp(
                lightingManager.TimeOfDay,
                nightTime,
                Time.deltaTime * transitionSpeed
            );
        }

        // Плавный переход к дню
        else
        {
            lightingManager.TimeOfDay = Mathf.Lerp(
                lightingManager.TimeOfDay,
                dayTime,
                Time.deltaTime * transitionSpeed
            );
        }
    }

    // КНОПКА NIGHT
    public void SwitchToNight()
    {
        goingToNight = true;
    }

    // КНОПКА DAY
    public void SwitchToDay()
    {
        goingToNight = false;
    }

    // TOGGLE
    public void ToggleDayNight()
    {
        goingToNight = !goingToNight;
    }
}