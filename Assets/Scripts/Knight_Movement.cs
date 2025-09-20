using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Movement : MonoBehaviour
{
    [SerializeField]
    private GameObject character;
    [SerializeField]
    private Animator animator;
    private Tweener tweener;
    public AudioSource audio;

    private Vector3 topLeft = new Vector3(16f, 20f, -0.2f);
    private Vector3 topRight = new Vector3(21f, 20f, -0.2f);
    private Vector3 bottomRight = new Vector3(21f, 16f, -0.2f);
    private Vector3 bottomLeft = new Vector3(16f, 16f, -0.2f);

    private Vector3 pastPosition;
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
        if (startPos == topLeft)
        {
            Vector3 endPos = new Vector3(21f, 20f, -0.2f);
            float duration = 1.25f;
            tweener.AddTween(character.transform, startPos, endPos, duration);
        }
        if (startPos == topRight)
        {
            Vector3 endPos = new Vector3(21f, 16f, -0.2f);
            float duration = 1f;
            tweener.AddTween(character.transform, startPos, endPos, duration);
        }
        if (startPos == bottomRight)
        {
            Vector3 endPos = new Vector3(16f, 16f, -0.2f);
            float duration = 1.25f;
            tweener.AddTween(character.transform, startPos, endPos, duration);
        }
        if (startPos == bottomLeft)
        {
            Vector3 endPos = new Vector3(16f, 20f, -0.2f);
            float duration = 1f;
            tweener.AddTween(character.transform, startPos, endPos, duration);
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
    private void playAudio()
    {
        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }
}
