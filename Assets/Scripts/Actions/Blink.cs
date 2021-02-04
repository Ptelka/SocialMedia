using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : Action
{
    [SerializeField] private GameObject obj;
    [SerializeField] private float duration;
    
    private float timer;
    private float blinkTime;
    private bool visible = true;
    private new Renderer renderer;

    void Start()
    {
        renderer = obj.GetComponent<Renderer>();
        timer = duration + 1;
    }

    void Update()
    {
        if (timer > duration)
        {
            renderer.enabled = true;
            return;
        }
        
        timer += Time.deltaTime;
        blinkTime -= Time.deltaTime;
        
        if (blinkTime < 0)
        {
            visible = !visible;
            blinkTime = Random.Range(0, 0.2f);
            renderer.enabled = visible;
        }
    }

    public override void Execute()
    {
        timer = 0;
    }
}
