using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovementEffects : MonoBehaviour
{
    [SerializeField] private Transform jumper;
    [SerializeField] private Transform shaker;
    [SerializeField] private Transform puncher;
    [SerializeField] private Transform target;

    [SerializeField] private MeshRenderer mesh;

    public void Jump()
    {
        jumper.DOJump(new Vector3(0f, 5f, 0f), 3, 1, 0.5f).SetEase(Ease.InOutSine);
    }

    public void Shake()
    {
        shaker.DOShakePosition(0.5f, 0.5f);
        shaker.DOShakeRotation(0.5f, 0.5f);
        shaker.DOShakeScale(0.5f, 0.5f);
    }

    public void Punch()
    {
        puncher.DOPunchPosition(Vector3.right * 2, 0.5f, 0, 0);
        target.DOShakePosition(0.5f, 0.5f, 10).SetDelay(0.5f * 0.5f);
    }

    public void ChangeMesh()
    {
        mesh.material.DOColor(Random.ColorHSV(), 0.3f).OnComplete(ChangeMesh);
    }
}
