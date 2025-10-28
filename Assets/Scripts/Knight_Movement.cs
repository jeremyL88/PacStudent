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
    public new AudioSource footsteps;
    public new AudioSource coin;

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
        Inputs();
        
        if (tweener.activeTween == null && lastInput != null)
        {

                Vector3 endPos = inputDirection(startPos, lastInput);

                if (!IsWall(endPos) && !IsGhostWall(endPos))
                {
                    currentInput = lastInput;
                    //Debug.Log("moving");
                    float duration = 0.2f;
                    tweener.AddTween(character.transform, startPos, endPos, duration);
                    return;
                }
                
        }
        if (tweener.activeTween == null && currentInput != null)
            {
                Vector3 endPos = inputDirection(startPos, currentInput);
                if (!IsWall(endPos) && !IsGhostWall(endPos))
                {
                    float duration = 0.2f;
                    tweener.AddTween(character.transform, startPos, endPos, duration);
                }
            }
        playAnimation();
        playCoin(startPos);
    }

    private void Inputs()
    {
        if (Input.GetKey(KeyCode.A))
        {
            lastInput = "a";
        }
        if (Input.GetKey(KeyCode.W))
        {
            lastInput = "w";
        }
        if (Input.GetKey(KeyCode.S))
        {
            lastInput = "s";
        }
        if (Input.GetKey(KeyCode.D))
        {
            lastInput = "d";
        }
    }

    private Vector3 inputDirection(Vector3 startPos, string input)
    {
        if (input == "a") //left
        {
            return startPos + Vector3.left;
        }
        if (input == "w") //up
        {
            return startPos + Vector3.up;
        }
        if (input == "s") //down
        {
            return startPos + Vector3.down;
        }
        if (input == "d") //right
        {
            return startPos + Vector3.right;
        }
        return startPos;
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
    private bool IsGhostWall (Vector3 endPos)
    {
        GameObject[] allWalls = GameObject.FindGameObjectsWithTag("GhostWall");
        foreach (GameObject wall in allWalls)
        {
            if (endPos.x == wall.transform.position.x && endPos.y == wall.transform.position.y)
            {
                return true;
            }
        }
        return false;
    }
    private bool IsCoin(Vector3 startPos)
    {
        GameObject[] coinSprites = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject coin in coinSprites)
        {
            Vector3 p2 = coin.transform.position;
            float distance = Vector3.Distance(startPos, p2);

            if (distance <= 0.15)
            {
                Debug.Log("coin");
                return true;
            }
        }
        return false;
    }

    private void playAnimation()
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
        if (!footsteps.isPlaying)
        {
            footsteps.Play();
        }
        
    }
    private void playCoin(Vector3 startPos)
    {

        if (IsCoin(startPos) && !coin.isPlaying && tweener.activeTween != null)
        {
            coin.Play();
        }
    }
}
