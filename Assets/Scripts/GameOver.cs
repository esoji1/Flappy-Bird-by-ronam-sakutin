using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    private void OnEnable()
    {
        _bird.GameOver += SropGame;
    }

    private void OnDisable()
    {
        _bird.GameOver -= SropGame;
    }

    private void SropGame()
    {
        Time.timeScale = 0;
    }
}
