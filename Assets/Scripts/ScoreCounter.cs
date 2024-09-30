using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public void Add()
    {
        _score++;
    }

    public void Reset()
    {
        _score = 0;
    }
}
