using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private GameObject cardBack;
    [SerializeField] private Sprite image;
    [SerializeField] private SceneController2d controller2D;
    private int _id;

    public int id {
        get { return _id; }
    }

    public void SetCard(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void OnMouseDown()
    {
        if (cardBack.activeSelf && controller2D.canReveal)
        {
            cardBack.SetActive(false);
            controller2D.CardRevealed(this);
        }
    }

    public void Unreveal()
    {
        cardBack.SetActive(true);
    }
}
