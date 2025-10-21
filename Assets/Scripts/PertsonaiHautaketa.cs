using UnityEngine;
using UnityEngine.UIElements;

public class PertsonaiHautaketa : MonoBehaviour
{

    [SerializeField] private GameObject ScoreCanvas;
    [SerializeField] private GameObject DinoSprite;
    [SerializeField] private GameObject FrogSprite;

    private void Start()
    {
        Time.timeScale = 0f;
    }


    private void BeginGame()
    {
        ScoreCanvas.SetActive(true);
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void HautatuDino()
    {
        DinoSprite.SetActive(true);
        FrogSprite.SetActive(false);
        BeginGame();
    }
    public void HautatuFrog()
    {
        DinoSprite.SetActive(false);
        FrogSprite.SetActive(true);
        BeginGame();
    }
}
