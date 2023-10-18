using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class ChainMovement : MonoBehaviour
{
    [SerializeField] private Transform[] shapes;
    
    void Start()
    {
        shapes[0].DOMoveX(7, Random.Range(1f, 2f)).OnComplete(() =>
        {
            shapes[1].DOMoveX(7, Random.Range(1f, 2f)).OnComplete(() =>
            {
                shapes[2].DOMoveX(7, Random.Range(1f, 2f)).OnComplete(() =>
                {
                    foreach (var shape in shapes)
                    {
                        shape.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce);
                    }
                });
            });
        });

        // var sequence = DOTween.Sequence();
        //
        // foreach (var shape in shapes)
        // {
        //     sequence.Append(shape.DOMoveX(7, Random.Range(1f, 2f)));
        // }
        //
        // sequence.OnComplete(() =>
        // {
        //     foreach (var shape in shapes)
        //     {
        //         shape.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce);
        //     }
        // });
        
        // AsyncMove();
        
        // Tasks();
    }

    async void AsyncMove()
    {
        foreach (var shape in shapes)
        {
            await shape.DOMoveX(7, Random.Range(1f, 2f)).SetEase(Ease.InOutQuad).AsyncWaitForCompletion();
        }
    }

    async void Tasks()
    {
        var tasks = new List<Task>();
        
        foreach (var shape in shapes)
        {
            tasks.Add(shape.DOMoveX(7, Random.Range(1f, 2f)).SetEase(Ease.InOutQuad).AsyncWaitForCompletion());
        }

        await Task.WhenAll(tasks);

        foreach (var shape in shapes)
            shape.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce);
    }
}
