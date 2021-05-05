using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    int health = 3;
    public Image[] hearts;
    bool hasCooldown = false;

    public SceneChanger changeScene;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if (GetComponent<PlayerMovement>().isGrounded)
            {
                SubstractHealth();
            }
        }
    }

    void SubstractHealth()
    {
        if(!hasCooldown)
        {
            if(health > 0)
            {
                health--;
                hasCooldown = true;

                StartCoroutine(Cooldown());
            }

            if(health <= 0)
            {
                changeScene.ChangeSceneTo("LoseScene");
            }

            EmptyHearts();
        }
    }

    void EmptyHearts()
    {
        for(int i = 0; i < hearts.Length; i ++)
        {
            if (health - 1 < i)
                hearts[i].gameObject.SetActive(false);
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.5f);
        hasCooldown = false;

        StopCoroutine(Cooldown());
    }
}
