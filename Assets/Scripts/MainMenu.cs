using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public UIDocument document;
    // Start is called before the first frame update

    private void Awake()
    {
        var root = document.rootVisualElement;
        var VolumeSlider = root.Q<SliderInt>("VolumeSlider");
        VolumeSlider.RegisterValueChangedCallback(evt =>
        {
            Debug.Log(evt.newValue);
        });
        var optionsButton = root.Q<VisualElement>("settings-button");
        var optionsContainer = root.Q<VisualElement>("OptionsContainer");
        optionsContainer.AddToClassList("hide");
        optionsButton.RegisterCallback<MouseUpEvent>(ev =>
        {
            // Toggle the 'hide' class on optionsContainer when the button is clicked
            optionsContainer.ToggleInClassList("hide");
        });
        var startButton = root.Q<Button>("start-button");
        startButton.RegisterCallback<MouseUpEvent>(ev =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    ;        });
        var exitButton = root.Q<Button>("exit-button");
        exitButton.RegisterCallback<MouseUpEvent>(ev =>
        {
            Debug.Log("bye");
            Application.Quit(); 
        });
    }
}
