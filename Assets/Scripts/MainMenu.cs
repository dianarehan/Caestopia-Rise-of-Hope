using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public UIDocument document;
    // Start is called before the first frame update
    AudioSource audioSource;
    public AudioClip clip;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        var root = document.rootVisualElement;
        var VolumeSlider = root.Q<SliderInt>("VolumeSlider");
        VolumeSlider.RegisterValueChangedCallback(evt =>
        {
            float volumeValue = evt.newValue;
            Debug.Log(evt.newValue);
            audioSource.volume = volumeValue/100;
        });
        var optionsButton = root.Q<VisualElement>("settings-button");
        var optionsContainer = root.Q<VisualElement>("OptionsContainer");
        //optionsContainer.AddToClassList("hide");
        optionsButton.RegisterCallback<MouseUpEvent>(ev =>
        {
            audioSource.PlayOneShot(clip);

            optionsContainer.ToggleInClassList("hide");
        });
        var startButton = root.Q<Button>("start-button");
        startButton.RegisterCallback<MouseUpEvent>(ev =>
        {
            audioSource.PlayOneShot(clip);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });
        var exitButton = root.Q<Button>("exit-button");
        exitButton.RegisterCallback<MouseUpEvent>(ev =>
        {
            audioSource.PlayOneShot(clip);

            Debug.Log("bye");
            Application.Quit(); 
        });
    }
}
