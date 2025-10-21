using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElurreanErori : MonoBehaviour
{
    [SerializeField] float Delay = 1f;
    [SerializeField] ParticleSystem CrashEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Elurra"))
        {
            // Invoke("GameOver", Delay);
            CrashEffect.Play();
            this.GetComponent<PlayerController>().BlockControlls();
            StartCoroutine(GameOver2());
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator GameOver2()
    {
        yield return new WaitForSeconds(Delay);
        SceneManager.LoadScene(0);

    }
}
