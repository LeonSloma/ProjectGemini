using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitchHorizontal : Interactable
{

    public int direction;

    private PlayerController _player;

    public override void Interact()
    {
        _player.FlipHorizontal(direction);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            _player = col.GetComponentInParent<PlayerController>();
            interactIndicator.SetActive(true);
            col.GetComponentInParent<PlayerController>().SetInteractable(this);
        }
    }
}
