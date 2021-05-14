using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] Sprite damagedSprite;
    [SerializeField] Sprite damagedMoreSprite;
    [SerializeField] AudioClip soundEffect;
    [SerializeField] GameObject sparklesVFX;

    public int damaged = 0;
    private SpriteRenderer spriteRenderer;
    private LevelScript levelScript;
    private GameStatus gameStatus;

    public void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        levelScript = FindObjectOfType<LevelScript>();
        gameStatus = FindObjectOfType<GameStatus>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Unbreakable") {
            return;
        }


        if (damaged == 0)
        {
            damaged++;
            spriteRenderer.sprite = damagedSprite;
        }
        //else if (damaged == 1) {
        //    damaged += 1;
        //    spriteRenderer.sprite = damagedMoreSprite;
        //}
        else
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(soundEffect, Camera.current.transform.position);
        TriggerSparklesVFX();
        levelScript.DecrementBlock();
        gameStatus.IncrementGameScore();
        Destroy(gameObject);
    }

    private void TriggerSparklesVFX() {
        var vfx = Instantiate(sparklesVFX, transform.position, Quaternion.identity);
        Destroy(vfx, 1);
    }
}
