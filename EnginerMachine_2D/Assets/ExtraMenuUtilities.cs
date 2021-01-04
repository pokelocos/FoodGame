using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RA.Utilities
{
    public class ExtraMenuUtilities : MonoBehaviour
    {
        public void LoadScene(string name)
        {
            Debug.Log("Load Scene: " + name);
            SceneManager.LoadScene(name);
        }

        public void LoadScene(int id)
        {
            Debug.Log("Load Scene: " + id);
            SceneManager.LoadScene(id);
        }

        public void Quit()
        {
            Application.Quit();
        }

        //Open web page
        public void OpenWebPage(string url)
        {
            Application.OpenURL(url);
        }
    }
}
