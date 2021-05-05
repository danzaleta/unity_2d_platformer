using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public static int collectableQuantity = 0;
    
    Text collectableText;
    ParticleSystem collectableParticle;
    AudioSource collectableAudio;

    // Start is called before the first frame update
    void Start()
    {
        collectableQuantity = 0;
        collectableText = GameObject.Find("CollectableQuantityText").GetComponent<Text>();
        collectableParticle = GameObject.Find("CollectableParticle").GetComponent<ParticleSystem>();
        collectableAudio = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            collectableParticle.transform.position = transform.position;
            collectableParticle.Play();
            collectableAudio.Play();
            gameObject.SetActive(false);
            collectableQuantity++;
            collectableText.text = collectableQuantity.ToString();
        }
    }
}
