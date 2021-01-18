using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
    
{
    //config parameters (assign assets and files to it to work)
    [SerializeField] AudioClip hittingTheBlock;
    [SerializeField] GameObject blockSparklesVFX;
 
    [SerializeField] Sprite[] hitSprite;

    //cashed reference (just saying that name level can be assigned to this class)
    Level level;

    //state variables (checks game aspects' statuses)

    [SerializeField] int timesHit;  //It is serialized only for bug purposes

    private void Start()
    {
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
      
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprite.Length + 1;
        if (timesHit >= maxHits)
        {


            DestroyBlock();
        } else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {

        int spriteIndex = timesHit -1;
        if (hitSprite[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];
        } else
        {
            Debug.LogError("Block sprite is missing from an array which is in the game object: " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
      
            AudioSource.PlayClipAtPoint(hittingTheBlock, Camera.main.transform.position);
            level.BlocksDestroyed();
            Destroy(gameObject);
            FindObjectOfType<GameStatus>().AddToScore();
            TriggeringSparklesVFX();
        
        
    }
    private void TriggeringSparklesVFX ()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1);
    }
}
