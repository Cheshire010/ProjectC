using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetOptionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void TutoScene()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    public void SetTitle()
    {
        SceneManager.LoadScene("SetCarScene");
    }
    public void SetOption()
    {
        SceneManager.LoadScene("TestScene");
    }
    //public void SetOtion_1()
    //{
    //    SceneManager.LoadScene("TestScene1");
    //}
}
