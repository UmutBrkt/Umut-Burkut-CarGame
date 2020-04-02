using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TurningApplier : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool left;
    public bool right;
  
    public void OnPointerDown(PointerEventData eventData)//right and left turning control
    {
        if (right)
        {
            
           foreach (PlayerMove player in PlayerMove.all)
            {
                player.TurnControl(false,true);
            }
        }
        if (left)
        {
            foreach (PlayerMove player in PlayerMove.all)
            {
                player.TurnControl(true, false);
            }
        }

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        foreach (PlayerMove player in PlayerMove.all)
        {
            player.TurnControl(false, false);
        }
    }
}
