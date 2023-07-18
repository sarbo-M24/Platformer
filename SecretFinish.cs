using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretFinish : MonoBehaviour
{

    private AudioSource Sfinish;
    private void Start()
    {
        Sfinish = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            CompleteSLevel();
            Sfinish.Play();
        }
    }

    private void CompleteSLevel()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
