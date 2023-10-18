using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField] private Transform outerShape;
    [SerializeField] private Transform innerShape;
    
    [SerializeField] private float cycleLength = 2f;
    
    [SerializeField] private bool shouldMove = false;
    [SerializeField] private Transform destination;
    [SerializeField] private Ease easeType = Ease.Linear;
    
    [SerializeField] private bool shouldLoop = false;
    [SerializeField] private int noOfCycles = 1;
    [SerializeField] private LoopType loopType = LoopType.Restart;

    [SerializeField] private bool shouldRotate = false;
    
    void Start()
    {
        if (innerShape != null)
        {
            if (shouldMove)
            {
                Move(outerShape);
                MoveInnerShape(innerShape);
            }

            if (shouldRotate)
                Rotate(innerShape);       
        }
        else
        {
            if (shouldMove)
            {
                Move(outerShape);
            }

            if (shouldRotate)
                Rotate(outerShape);
        }
    }

    private void Move(Transform obj)
    {
        Vector3 dest = destination.position;
            
        if (shouldLoop)
            obj.DOMove(dest, cycleLength).SetEase(easeType).SetLoops(noOfCycles, loopType);
        else
            obj.DOMove(dest, cycleLength).SetEase(easeType);
    }

    private void MoveInnerShape(Transform obj)
    {
        Vector3 dest = destination.position;
        
        obj.DOLocalMove(dest, cycleLength).SetEase(easeType).SetLoops(noOfCycles, loopType);
    }

    private void Rotate(Transform obj)
    {
        obj.DORotate(new Vector3(0, 360, 0), cycleLength * 0.5f, RotateMode.FastBeyond360).SetEase(easeType).SetLoops(noOfCycles, loopType);
    }
}
