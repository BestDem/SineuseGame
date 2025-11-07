using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ViewUpController : MonoBehaviour
{
    [SerializeField] private float speedChangeLin = 3;
    //private int[] Zcoord = new int[3];
    private Rigidbody player;
    private int currentPos = 1;
    private bool isShifting = false;
    private float shift = 3f;
    private float shiftTime = 0.05f;

    private void Start()
    {
        player = GetComponent<Rigidbody>();

        //Zcoord[0] = -shift;
        //Zcoord[1] = 0;
        //Zcoord[2] = shift;
    }
    public void Move(float direction)
    {
        if (isShifting) {
            return;
        }
        if (direction == 0)    //вниз перешел
        {
            Down();
        }
        else if (direction == 1)  //вверх перешел
        {
            Up();
        }
        else
        {
            //AnimatorController.singltonAnim.PlayAnimations("isRun", true);
        }
    }

    private void Up()
    {
        if (currentPos != 2)
        {
            currentPos = currentPos + 1;
            //Vector3 targetUp = new Vector3(transform.position.x, transform.position.y, transform.position.z + shift);
            //transform.position = targetUp;
            StartCoroutine(DoShift(1f));
            isShifting = true;

            //            transform.position = Vector3.Lerp(transform.position, targetUp, speedChangeLin * Time.deltaTime);
        }
        else
        {

        }
    }

    private void Down()
    {
        if (currentPos != 0)
        {
            currentPos = currentPos - 1;

            //Vector3 targetDown = new Vector3(transform.position.x, transform.position.y, transform.position.z - shift);
            //transform.position = targetDown;
            StartCoroutine(DoShift(-1f));
            isShifting = true;
        }
        else
        {

        }
    }

    public void Reset()
    {
        currentPos = 1;
        //Vector3 target = new Vector3(transform.position.x, transform.position.y, Zcoord[currentPos]);
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
        isShifting = false;
    }
}
