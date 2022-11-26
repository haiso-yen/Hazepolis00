using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyThrough : MonoBehaviour
{

    private SkeletonAnimation skeletonAnimation;

    private void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            skeletonAnimation.state.SetAnimation(0, "animation", false);
        }
    }
}
