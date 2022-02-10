using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Team6.Toofan.Managers
{
    public class SceneController : MonoBehaviour
    {
       public void NextScene()
        {
            SceneManager.LoadScene("Level_Main_2");
        }
    }

}