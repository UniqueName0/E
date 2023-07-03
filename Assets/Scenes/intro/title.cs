using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{
    private UIDocument document;


        
    // Start is called before the first frame update
    void Start()
    {
        this.document = GetComponent<UIDocument>();
        this.document.rootVisualElement.Q<Button>("startButton").RegisterCallback<ClickEvent>(StartButtonClicked);

    }

    void StartButtonClicked(ClickEvent evt)
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    
}
