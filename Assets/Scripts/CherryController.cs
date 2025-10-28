using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CherryController : MonoBehaviour
{
    [SerializeField]
    private GameObject gem;
    private float timer = 0;
    private GameObject spawnedGem;
    private float duration = 10f;
    private float moveTime = 0f;

    private Vector3 startPos = Vector3.zero;
    private Vector3 endPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log((int)timer);

        if (spawnedGem == null)
        {
            if (timer >= 5)
            {
                CherrySpawn();
                Debug.Log("Cherry spawned");
            }
        }
        if (spawnedGem != null)
        {
            moveTime += Time.deltaTime;
            float time = moveTime / duration;

            spawnedGem.transform.position = Vector3.Lerp(startPos, endPos, time);

            if (time >= 1)
            {
                Destroy(spawnedGem);
                spawnedGem = null;
                timer = 0;
                time = 0;
                Debug.Log("Cherry destroyed");
            }
        }

    }
    private void CherrySpawn()
    {
        int side = Random.Range(0, 4);
        
        //middle of the level is (26.5, 7)
        if (side == 0) //to left
        {
            Debug.Log("left side");
            startPos = new Vector3(11, Random.Range(-9, 24), -0.1f);
            float originDiff = startPos.y - 7f;
            float oppositeStart = 7f - originDiff;
            endPos = new Vector3(42, oppositeStart, -0.1f);
        }
        if (side == 1) //to right
        {
            Debug.Log("right side");
            startPos = new Vector3(42, Random.Range(-9, 24), -0.1f);
            float originDiff = startPos.y - 7f;
            float oppositeStart = 7f - originDiff;
            endPos = new Vector3(11, oppositeStart, -0.1f);
        }
        if (side == 2) //to top
        {
            Debug.Log("top side");
            startPos = new Vector3(Random.Range(11, 43), 23, -0.1f);
            float originDiff = startPos.x - 26.5f;
            float oppositeStart = 26.5f - originDiff;
            endPos = new Vector3(oppositeStart, -9, -0.1f);
        }
        if (side == 3) //to bottom
        {
            Debug.Log("bottom side");
            startPos = new Vector3(Random.Range(11, 43), -9, -0.1f);
            float originDiff = startPos.x - 26.5f;
            float oppositeStart = 26.5f - originDiff;
            endPos = new Vector3(oppositeStart, 23, -0.1f);
        }
        spawnedGem = Instantiate(gem, startPos, Quaternion.identity);
        moveTime = 0;
    }
}
