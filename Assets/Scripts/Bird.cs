using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(BirdCollosionHandler))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private ScoreCounter _scoreCounter;
    private BirdCollosionHandler _handler;

    public event Action GameOver;

    public void Reset()
    {
        _scoreCounter.Reset();
        _birdMover.Reset();
        
    }

    private void Awake()
    {
        _birdMover = GetComponent<BirdMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<BirdCollosionHandler>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {

        if (interactable is Pipe || interactable is Ground)
        {
            GameOver?.Invoke();
        }

        else if(interactable is ScoreZone)
        {
            _scoreCounter.Add();
        }
    }
}

