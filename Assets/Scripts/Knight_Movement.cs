using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Movement : MonoBehaviour
{
    [SerializeField]
    private GameObject character;
    private Tweener tweener;
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPos = character.transform.position;
        if (Input.GetKeyDown("a"))
        {
            Vector3 endPos = new Vector3(-2.0f, 0.5f, 0.0f);
            float duration = 1.5f;
            tweener.AddTween(character.transform, startPos, endPos, duration);
        }
        if (Input.GetKeyDown("d"))
        {
            Vector3 endPos = new Vector3(2.0f, 0.5f, 0.0f);
            float duration = 1.5f;
            tweener.AddTween(character.transform, startPos, endPos, duration);
        }
        if (Input.GetKeyDown("s"))
        {
            Vector3 endPos = new Vector3(0.0f, 0.5f, -2.0f);
            float duration = 0.5f;
            tweener.AddTween(character.transform, startPos, endPos, duration);
        }
        if (Input.GetKeyDown("w"))
        {
            Vector3 endPos = new Vector3(0.0f, 0.5f, 2.0f);
            float duration = 0.5f;
            tweener.AddTween(character.transform, startPos, endPos, duration);
        }
    }
}
