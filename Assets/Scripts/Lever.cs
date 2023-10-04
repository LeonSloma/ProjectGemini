using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
    public LeverBlock[] objects;
    SpriteRenderer sprite;

    public override void Interact()
    {
        foreach (var block in objects) block.Toggle();
        sprite.flipX = !sprite.flipX;
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        interactIndicator.SetActive(false);
    }

}
