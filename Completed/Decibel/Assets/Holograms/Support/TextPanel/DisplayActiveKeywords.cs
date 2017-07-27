using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HoloToolkit.Unity.InputModule;

/// <summary>
/// Shows the list of available voice commands on the KeywordManager.cs script.
/// </summary>
public class DisplayActiveKeywords : MonoBehaviour
{
    Text textComponent;
    string originalText = string.Empty;
    StringBuilder sb = new StringBuilder();

    SpeechInputSource[] keywordSources;

    void Start()
    {
        textComponent = this.gameObject.GetComponent<Text>();
        originalText = textComponent.text;

        // Find the KeywordManager scripts.
        keywordSources = FindObjectsOfType<SpeechInputSource>();
        if (keywordSources == null)
        {
            Debug.LogError("Could not find KeywordManager.cs anywhere.");
            return;
        }

        // Reset the text panel.
        sb.Length = 0;
        sb.AppendLine(originalText);

        // Ensure we display active commands on all keyword managers.
        foreach (var keySource in keywordSources)
        {
            AddActiveKeywords(keySource);
        }

        textComponent.text = sb.ToString();
    }

    private void AddActiveKeywords(SpeechInputSource keywordSource)
    {
        // Extract the Keywords within this source and append to the output text string
        foreach (var keyword in keywordSource.Keywords)
        {
            sb.AppendLine(keyword.Keyword);
        }        
    }
}
