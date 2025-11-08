using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ViewUpController : MonoBehaviour
{
    private Rigidbody player;
    private int currentPos = 1;
    private float shift = 3f;
    private float shiftTime = 0.05f;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }
    public void Move(float direction)
    {
        if (GameManager.isShifting) {
            return;
        }

        if (direction == 0)    //вниз перешел
        {
            GameManager.TriggerMovement();
            Down();
        }
        else if (direction == 1)  //вверх перешел
        {
            GameManager.TriggerMovement();
            Up();
        }
        else
        {
            //AnimatorController.singltonAnim.PlayAnimations("isRun", true);
        }
    }

    private void Up()
    {
        if (currentPos < 2)
        {
            currentPos = currentPos + 1;
            StartCoroutine(DoShift(1f));
            GameManager.isShifting = true;
        }
        else
        {

        }
    }

    private void Down()
    {
        if (currentPos > 0)
        {
            currentPos = currentPos - 1;
            StartCoroutine(DoShift(-1f));
            GameManager.isShifting = true;
        }
        else
        {

        }
    }

    public void Reset()
    {
        currentPos = 1;
        Vector3 target = new Vector3(transform.position.x, transform.position.y, 0);
        transform.position = target;
    }
    IEnumerator DoShift(float direction)
    {
        int numIter = 10;
        float dz = shift / numIter * direction;
        float dtime = shiftTime / numIter;
        for (int i = 0; i < numIter; i++) 
        {
            yield return new WaitForSecondsRealtime(dtime);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + dz);
            if (GameManager.isPauseDeath)
            {
                break;
            }
        }
        GameManager.isShifting = false;
    }
}
