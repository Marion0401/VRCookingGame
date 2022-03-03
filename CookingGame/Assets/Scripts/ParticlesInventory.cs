using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesInventory : MonoBehaviour
{
    public static ParticlesInventory instance;

    [SerializeField] public ParticleSystem tomatoJuice;
    [SerializeField] public ParticleSystem breadCrumbs;
    [SerializeField] public ParticleSystem saladLeaves;
    [SerializeField] public ParticleSystem fryingBubbles;
    [SerializeField] public ParticleSystem starSuccess;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
