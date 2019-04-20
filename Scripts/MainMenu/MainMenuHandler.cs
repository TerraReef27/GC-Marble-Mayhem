using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    public Marble[] classes;
    int currentClass;
    public string[] names;
    public Text classText;
    public MovableMarble marble;

    void Start()
    {
        for(int i = 0; i < classes.Length; i++)
        {
            names[i] = classes[i].name;
        }
        classText.text = names[currentClass];
        currentClass = 0;

        marble.marbleData = classes[0];
        marble.updateMaterial();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void nextBtn()
    {
        if(currentClass < classes.Length - 1)
        {
            currentClass++;
        }
        else
        {
            currentClass = 0;
        }
        classText.text = names[currentClass];
        marble.marbleData = classes[currentClass];
        marble.updateMaterial();
    }

    public void previousBtn()
    {
        if(currentClass == 0)
        {
            currentClass = classes.Length - 1;
        }
        else
        {
            currentClass--;
        }
        classText.text = names[currentClass];
        marble.marbleData = classes[currentClass];
        marble.updateMaterial();
    }
}
