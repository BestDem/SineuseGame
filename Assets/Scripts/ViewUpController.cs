using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ViewUpController : MonoBehaviour
{
    [SerializeField] private float speedChangeLin = 3;
    private int[] Zcoord = new int[3];
    private Rigidbody player;
    private int currentPos = 1;

    private void Start()
    {
        player = GetComponent<Rigidbody>();

        Zcoord[0] = -3;
        Zcoord[1] = 0;
        Zcoord[2] = 3;
    }
    public void Move(float direction)
    {
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
            Vector3 targetUp = new Vector3(transform.position.x, transform.position.y, Zcoord[currentPos]);
            transform.position = targetUp;
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

            Vector3 targetDown = new Vector3(transform.position.x, transform.position.y, Zcoord[currentPos]);
            transform.position = targetDown;
        }
        else
        {

        }
    }

    public void Reset()
    {
        currentPos = 1;
        Vector3 target = new Vector3(transform.position.x, transform.position.y, Zcoord[currentPos]);
        transform.position = target;
    }
}
