using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_knight : MonoBehaviour
{
    public GameObject knight;
    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MousePosition();
        
    }

    private void MousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        Debug.Log(mousePos.x);

        //if (mousePos.x > 670 && mousePos.x < 830)
        if (mousePos.x > knight.transform.position.x - 40 && mousePos.x < knight.transform.position.x + 40)
        {
            animator.SetTrigger("MoveDown");
        }
        if (mousePos.x <= knight.transform.position.x - 40)
        {
            animator.SetTrigger("MoveLeft");
        }
        if (mousePos.x >= knight.transform.position.x + 40)
        {
            animator.SetTrigger("MoveRight");
        }
    }
}
