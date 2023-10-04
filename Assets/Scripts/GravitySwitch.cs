using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : Interactable
{

    public override void Interact()
    {
        PlayerController.FlipPlayersVertical();
    }
    


}
