using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour{
    
public ParticleSystem spark;
public int rate = 20;

    void Start(){
        spark = GetComponent<ParticleSystem>();
        StartCoroutine(Sparkstart(0.2f));
    }

    public IEnumerator Sparkstart(float duration){
        var emm = spark.emission;
        emm.rateOverTime = rate;
        yield return new WaitForSeconds(duration);
        emm.rateOverTime = 0f;
        float rand1 = Random.Range(0.5f, 3f);
        yield return new WaitForSeconds(rand1);
        float during = Random.Range(0.1f, 0.5f);
        StartCoroutine(Sparkstart(during));
    }
}
