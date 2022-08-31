using System;
using UnityEngine;
[RequireComponent(typeof(ParticleSystem))]
public class FireParticles : MonoBehaviour
{
    [SerializeField] private int MinParticles = 200;
    [SerializeField] private int MaxParticles = 1000;
    public Func<float> PartBurned { private get; set; }
    private ParticleSystem ParticleSystem;
    private void OnEnable()
    {
        ParticleSystem = GetComponent<ParticleSystem>();
    }
    private void Start()
    {
        if (PartBurned == null)
        {
            Debug.Log($"Particle System disabled because there was no function set");
            gameObject.SetActive(false);
            return;
        }
    }
    private void Update()
    {
        float frac = (MaxParticles - MinParticles) * PartBurned() + MinParticles;
        var t = ParticleSystem.emission;
        t.rateOverTime = new ParticleSystem.MinMaxCurve(frac); 
    }
    public void StartBurning(object obj, EventArgs args)
    {
        ParticleSystem.Play();
    }
    public void StopBurning(object obj, EventArgs args)
    {
        ParticleSystem.Stop();
    }
}