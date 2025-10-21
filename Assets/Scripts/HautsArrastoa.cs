using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HautsArrastoa : MonoBehaviour
{
    [SerializeField] ParticleSystem HautsArrastoaEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Elurra"))
        {
            HautsArrastoaEffect.Play();
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Elurra"))
        {
            HautsArrastoaEffect.Stop();
        }
    }
}
