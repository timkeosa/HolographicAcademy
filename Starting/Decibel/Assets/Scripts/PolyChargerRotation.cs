using System;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class PolyChargerRotation : MonoBehaviour, INavigationHandler
{
    [Tooltip("How rapidly should the charger rotate.")]
    [Range(2.0f, 100.0f)]
    public float RotationSensitivity = 10.0f;

    private void PerformRotation(NavigationEventData eventData)
    {
        // This will help control the amount of rotation.
        float rotationFactor = eventData.CumulativeDelta.x * RotationSensitivity;

        // Rotate along the Y axis using rotationFactor.
        transform.parent.Rotate(new Vector3(0, -1 * rotationFactor, 0));
    }

    private void Start()
    {
    }

    /// <summary>
    /// Handles navigation start messages.
    /// </summary>
    public void OnNavigationStarted(NavigationEventData eventData)
    {
        PerformRotation(eventData);
    }

    public void OnNavigationUpdated(NavigationEventData eventData)
    {
        PerformRotation(eventData);
    }

    public void OnNavigationCompleted(NavigationEventData eventData)
    {
    }

    public void OnNavigationCanceled(NavigationEventData eventData)
    {
    }
}