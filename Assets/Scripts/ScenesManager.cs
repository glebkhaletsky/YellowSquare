using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField]
    Image AlphaImg;
    private void Start()
    {
        AlphaImg.enabled = false;
    }
    public void Repet(int _sceneNumber)
    {

        SceneManager.LoadScene(0);
    }

    public void Next()
    {
        AlphaImg.enabled = true;
        AlphaImg.CrossFadeAlpha(255, 1f, true);
        Invoke("Play", 1.5f);
    }

   void Play()
   { 
        SceneManager.LoadScene(0);
   }
}
