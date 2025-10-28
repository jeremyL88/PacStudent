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
    private string currentInput;

    private GameObject[] wall;
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
        

        //Debug.Log(tweener.activeTween);
        Left();
        Up();
        Down();
        Right();
        
        if (tweener.activeTween == null && lastInput != null)
        {
            if (currentInput == "a" && tweener.activeTween == null)
            {
                Vector3 endPos = new Vector3(character.transform.position.x - 1, character.transform.position.y , character.transform.position.z);
                if (IsWall(endPos))
                {
                    //lastInput = null;
                    return;
                }
                currentInput = lastInput;
                float duration = 0.2f;
                tweener.AddTween(character.transform, startPos, endPos, duration);
                //lastInput = null;
            }
            if (currentInput == "w" && tweener.activeTween == null)
            {
                Vector3 endPos = new Vector3(character.transform.position.x, character.transform.position.y + 1, character.transform.position.z);
                if (IsWall(endPos))
                {
                    //lastInput = null;
                    return;
                }
                currentInput = lastInput;
                float duration = 0.2f;
                tweener.AddTween(character.transform, startPos, endPos, duration);
                //lastInput = null;
            }
            if (currentInput == "s" && tweener.activeTween == null)
            {
                Vector3 endPos = new Vector3(character.transform.position.x, character.transform.position.y - 1, character.transform.position.z);
                if (IsWall(endPos))
                {
                    //lastInput = null;
                    return;
                }
                currentInput = lastInput;
                float duration = 0.2f;
                tweener.AddTween(character.transform, startPos, endPos, duration);
                //lastInput = null;
            }
            if (currentInput == "d" && tweener.activeTween == null)
            {
                Vector3 endPos = new Vector3(character.transform.position.x + 1, character.transform.position.y, character.transform.position.z);
                if (IsWall(endPos))
                {
                    //lastInput = null;
                    Debug.Log("hit a wall");
                    return;
                }
                currentInput = lastInput;
                Debug.Log("going right");
                float duration = 0.2f;
                tweener.AddTween(character.transform, startPos, endPos, duration);
                //lastInput = null;
            }
        }

        animation();
    }

    private void Left()
    {
        Vector3 startPos = character.transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            if (tweener.activeTween != null)
            {
                lastInput = "a";
                Debug.Log("Last input: left");
                return;
            }
            Vector3 endPos = new Vector3(startPos.x - 1, startPos.y, startPos.z);
            if (IsWall(endPos))
            {
                lastInput = "a";
                return;
            }
            currentInput = "a";
            float duration = 0.2f;
            tweener.AddTween(character.transform, startPos, endPos, duration);

            
        }
    }
    private void Up()
    {
        Vector3 startPos = character.transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            if (tweener.activeTween != null)
            {
                lastInput = "w";
                Debug.Log("Last input: up");
                return;
            }
            Vector3 endPos = new Vector3(startPos.x, startPos.y + 1, startPos.z);
            if (IsWall(endPos))
            {
                lastInput = "w";
                return;
            }
            currentInput = "w";
            float duration = 0.2f;
            tweener.AddTween(character.transform, startPos, endPos, duration);
            
        }
    }
    private void Down()
    {
        Vector3 startPos = character.transform.position;
        if (Input.GetKey(KeyCode.S))
        {
            if (tweener.activeTween != null)
            {
                lastInput = "s";
                Debug.Log("Last input: down");
                return;
            }
            Vector3 endPos = new Vector3(startPos.x, startPos.y - 1, startPos.z);
            if (IsWall(endPos))
            {
                lastInput = "s";
                return;
            }
            currentInput = "s";
            float duration = 0.2f;
            tweener.AddTween(character.transform, startPos, endPos, duration);
            
        }
    }
    private void Right()
    {
        Vector3 startPos = character.transform.position;
        if (Input.GetKey(KeyCode.D))
        {
            if (tweener.activeTween != null)
            {
                lastInput = "d";
                Debug.Log("Last input: right");
                return;
            }
            Vector3 endPos = new Vector3(startPos.x + 1, startPos.y, startPos.z);
            if (IsWall(endPos))
            {
                lastInput = "d";
                Debug.Log("wall in the way");
                return;
            }
            currentInput = "d";
            float duration = 0.2f;
            tweener.AddTween(character.transform, startPos, endPos, duration);
            
        }
    }
    private bool IsWall(Vector3 endPos)
    {
        GameObject[] allWalls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject wall in allWalls)
        {
            if (endPos.x == wall.transform.position.x && endPos.y == wall.transform.position.y)
            {
                return true;
            }
        }
        return false;
    }

    private void animation()
    {
        if (character.transform.position.x > pastPosition.x && pastPosition != character.transform.position)
        {
            animator.enabled = true;
            animator.SetTrigger("MoveRight");
            pastPosition = character.transform.position;
            playAudio();
        }
        if (character.transform.position.x < pastPosition.x && pastPosition != character.transform.position)
        {
            animator.enabled = true;
            animator.SetTrigger("MoveLeft");
            pastPosition = character.transform.position;
            playAudio();
        }
        if (character.transform.position.y > pastPosition.y && pastPosition != character.transform.position)
        {
            animator.enabled = true;
            animator.SetTrigger("MoveUp");
            pastPosition = character.transform.position;
            playAudio();
        }
        if (character.transform.position.y < pastPosition.y && pastPosition != character.transform.position)
        {
            animator.enabled = true;
            animator.SetTrigger("MoveDown");
            pastPosition = character.transform.position;
            playAudio();
        }
        if (tweener.activeTween == null)
        {
            animator.enabled = false;
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
