using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBlock : MonoBehaviour
{

    public bool inactive = false;

    SpriteRenderer sprite;
    Collider2D col;

    public void Toggle()
    {
        inactive = !inactive;

        Color color = sprite.color;

        if(inactive) color.a = 0.3f;
        else color.a = 1.0f;
        sprite.color = color;

        col.enabled = !col.enabled;
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        if(inactive)
        {
            Color color = sprite.color;
            color.a = 0.3f;
            sprite.color = color;
            col.enabled = false;
        }
    }

}
