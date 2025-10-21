using UnityEngine;
using UnityEngine.SceneManagement;

public class HelmugaraAilegatu : MonoBehaviour
{
    [SerializeField] float Delay = 1f;
    [SerializeField] ParticleSystem HelmugaEfectua;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HelmugaEfectua.Play();
            Invoke("LevelCleared", Delay);
        }
    }

    private void LevelCleared()
    {
         SceneManager.LoadScene(0);
    }
}
