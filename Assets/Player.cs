using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float zOffset = 3;
    [SerializeField] private float animationTime = 1f;
    [SerializeField] private float endRotation = -40f;

    private Quaternion start;

    void Start()
    {
        start = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = zOffset;
        transform.position = Camera.main.ScreenToWorldPoint(pos);

        if (Input.GetMouseButtonDown(0))
        {
            Restart();
            StartCoroutine(RotateHand());
        }
    }

    private void Restart()
    {
        transform.localRotation = start;
        StopAllCoroutines();
    }

    private IEnumerator RotateHand()
    {
        float time = 0;
        while (time < animationTime)
        {
            transform.localRotation = Quaternion.Lerp(start, start * Quaternion.Euler(endRotation, 0, 0), time / animationTime);
            time += Time.deltaTime;
            yield return null;
        }
        time = 0;
        Quaternion current = transform.localRotation;
        while (time < animationTime)
        {
            transform.localRotation = Quaternion.Lerp(current, start, time / animationTime);
            time += Time.deltaTime;
            yield return null;
        }
    }
}