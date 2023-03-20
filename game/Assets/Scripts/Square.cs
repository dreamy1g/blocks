using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{

    [SerializeField]
    private Color baseColor;

    [SerializeField]
    private Color offsetColor;

    [SerializeField]
    private SpriteRenderer renderer;

    public void Init(bool isOffset)
    {
        renderer.color = isOffset ? offsetColor : baseColor;
    }

   
}
