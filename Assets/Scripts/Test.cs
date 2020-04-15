using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
   public Transform player;
   public GameObject hand;
   public ParticleSystem particles;
   public float speed = 1.0f;
   private float startTime;
   private float journeyLength;
   public List<Star> targets = new List<Star>();


    void Start()
    {
        startTime = Time.time;
        
        
    }
    void Update()
    {
        Star highlightedStar = null;
        float smallestAngle = Mathf.Infinity;
        foreach(Star star in targets)
        {
            Transform target = star.transform;
            Vector3 targetDir = target.position - transform.position;
            float angle = Vector3.Angle(targetDir, hand.transform.forward);
            star.isHighlighted = false;
            if (angle < 10.0f && angle < smallestAngle)
            {
                smallestAngle = angle;
                highlightedStar = star;
            }
        }
        if(highlightedStar != null)
        {
            highlightedStar.isHighlighted = true;
            if (Input.GetButtonDown("XRI_Right_TriggerButton"))
            {
                journeyLength = Vector3.Distance(player.position, highlightedStar.transform.position);
                //float distCovered = (Time.time - startTime) * speed;
               // float fractionOfJourney = distCovered / journeyLength;
               // transform.position = Vector3.Lerp(hand.position, highlightedStar.transform.position, fractionOfJourney);
               // Debug.Log("travelled");
               StartCoroutine(LerpPos(player.position,highlightedStar.transform.position,journeyLength));
               particles.Play();
            }
        }
    }


     IEnumerator LerpPos(Vector3 start, Vector3 end, float journeyLength)
    {
        float t = 0;
        while(t < 1)
        {
            transform.position = Vector3.Lerp(start,end,t);
            t = t + Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
