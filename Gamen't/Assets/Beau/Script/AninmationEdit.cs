using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AninmationEdit : MonoBehaviour
{
    public Animator animator;
    private int pressed;

    public void PressedButon()
    {
        pressed++;
        
        if(pressed == 1)
        {
            animator.SetBool("Can animate", true);
            
        }
        if(pressed == 2)
        {
            animator.SetBool("Can animate", false);
            pressed = 0;
        }
    }
}
