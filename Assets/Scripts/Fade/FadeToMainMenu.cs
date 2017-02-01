using UnityEngine;
using System.Collections;

public class FadeToMainMenu : MonoBehaviour {

    FadeInFadeOut fade;
    float timer = 0;

    void Start()
    {
        fade = GameObject.FindObjectOfType<FadeInFadeOut>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
            fade.EndScene("MainMenu");
    }
}
