using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knight_Movement : MonoBehaviour
{
    [SerializeField]
    private GameObject character;
    [SerializeField]
    private Animator animator;
    private Tweener tweener;
    public new AudioSource audio;

    private Vector3 pastPosition;
    private string lastInput;
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        Application.targetFrameRate = 60;
        pastPosition = character.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPos = character.transform.position;

        Debug.Log(tweener.activeTween);
        Left();
        Up();
        Down();
        Right();
        
        if (tweener.activeTween == null && lastInput != null)
        {
            if (lastInput == "a")
            {
                Vector3 endPos = new Vector3(character.transform.position.x - 1, character.transform.position.y , character.transform.position.z);
                float duration = 0.5f;
                tweener.AddTween(character.transform, startPos, endPos, duration);
                lastInput = null;
                Debug.Log("going left");
            }
            if (lastInput == "w")
            {
                Vector3 endPos = new Vector3(character.transform.position.x, character.transform.position.y + 1, character.transform.position.z);
                float duration = 0.5f;
                tweener.AddTween(character.transform, startPos, endPos, duration);
                lastInput = null;
                Debug.Log("going up");
            }
            if (lastInput == "s")
            {
                Vector3 endPos = new Vector3(character.transform.position.x, character.transform.position.y - 1, character.transform.position.z);
                float duration = 0.5f;
                tweener.AddTween(character.transform, startPos, endPos, duration);
                lastInput = null;
                Debug.Log("going down");
            }
            if (lastInput == "d")
            {
                Vector3 endPos = new Vector3(character.transform.position.x + 1, character.transform.position.y, character.transform.position.z);
                float duration = 0.5f;
                tweener.AddTween(character.transform, startPos, endPos, duration);
                lastInput = null;
                Debug.Log("going right");
            }
        }
 

        if (character.transform.position.x > pastPosition.x && pastPosition != character.transform.position)
        {
            animator.SetTrigger("MoveRight");
            pastPosition = character.transform.position;
            playAudio();
        }
        if (character.transform.position.x < pastPosition.x && pastPosition != character.transform.position)
        {
            animator.SetTrigger("MoveLeft");
            pastPosition = character.transform.position;
            playAudio();
        }
        if (character.transform.position.y > pastPosition.y && pastPosition != character.transform.position)
        {
            animator.SetTrigger("MoveUp");
            pastPosition = character.transform.position;
            playAudio();
        }
        if (character.transform.position.y < pastPosition.y && pastPosition != character.transform.position)
        {
            animator.SetTrigger("MoveDown");
            pastPosition = character.transform.position;
            playAudio();
        }
    }

    private void Left()
    {
        Vector3 startPos = character.transform.position;
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (tweener.activeTween != null)
            {
                lastInput = "a";
                Debug.Log("Last input: left");
                return;
            }
            Vector3 endPos = new Vector3(character.transform.position.x - 1, character.transform.position.y, character.transform.position.z);
            float duration = 0.5f;
            tweener.AddTween(character.transform, startPos, endPos, duration);
            
        }
    }
    private void Up()
    {
        Vector3 startPos = character.transform.position;
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (tweener.activeTween != null)
            {
                lastInput = "w";
                Debug.Log("Last input: up");
                return;
            }
            Vector3 endPos = new Vector3(character.transform.position.x, character.transform.position.y + 1, character.transform.position.z);
            float duration = 0.5f;
            tweener.AddTween(character.transform, startPos, endPos, duration);
            
        }
    }
    private void Down()
    {
        Vector3 startPos = character.transform.position;
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (tweener.activeTween != null)
            {
                lastInput = "s";
                Debug.Log("Last input: down");
                return;
            }
            Vector3 endPos = new Vector3(character.transform.position.x, character.transform.position.y - 1, character.transform.position.z);
            float duration = 0.5f;
            tweener.AddTween(character.transform, startPos, endPos, duration);
            
        }
    }
    private void Right()
    {
        Vector3 startPos = character.transform.position;
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (tweener.activeTween != null)
            {
                lastInput = "d";
                Debug.Log("Last input: right");
                return;
            }
            Vector3 endPos = new Vector3(character.transform.position.x + 1, character.transform.position.y, character.transform.position.z);
            float duration = 0.5f;
            tweener.AddTween(character.transform, startPos, endPos, duration);
            
        }
    }

    private void playAudio()
    {
        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }
}
