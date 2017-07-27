using System;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace Academy.HoloToolkit.Unity
{
    public class GestureSoundHandler : MonoBehaviour, INavigationHandler
    {
        public AudioClip NavigationStartedClip;
        public AudioClip NavigationUpdatedClip;

        // A game object that will be used to contain the gesture audio source.
        // This object will be moved to the location of the object responding to the gesture.
        private GameObject audioSourceContainer;

        private AudioSource audioSource;

        private void Start()
        {
            audioSourceContainer = new GameObject("AudioSourceContainer", new Type[] { typeof(AudioSource) });
            audioSource = audioSourceContainer.GetComponent<AudioSource>();

            // Set the spatialize field of the audioSource to true.
            audioSource.spatialize = true;
            // Set the spatialBlend field of the audioSource to 1.0f.
            audioSource.spatialBlend = 1.0f;
            // Set the dopplerLevel field of the audioSource to 0.0f.
            audioSource.dopplerLevel = 0.0f;
            // Set the rolloffMode field of the audioSource to the Logarithmic AudioRolloffMode.
            audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        }

        public void OnNavigationCanceled(NavigationEventData eventData)
        {
            HandleGestureSound(null);
        }

        public void OnNavigationCompleted(NavigationEventData eventData)
        {
            HandleGestureSound(null);
        }

        public void OnNavigationStarted(NavigationEventData eventData)
        {
            HandleGestureSound(NavigationStartedClip);
        }

        public void OnNavigationUpdated(NavigationEventData eventData)
        {
            HandleGestureSound(NavigationUpdatedClip);
        }

        private void HandleGestureSound(AudioClip audioClip)
        {
            if (audioClip != null)
            {
                // Move the audio source container to the location of the focused object so that
                // the gesture sound is properly spatialized with the focused object.
                audioSourceContainer.transform.position = gameObject.transform.position;

                // Set the AudioSource clip field to the audioClip
                audioSource.clip = audioClip;

                // Play the AudioSource
                audioSource.Play();
            }
            else
            {
                // Stop the AudioSource
                audioSource.Stop();
            }
        }
    }
}