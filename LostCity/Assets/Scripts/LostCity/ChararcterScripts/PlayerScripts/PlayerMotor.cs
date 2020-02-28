using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Create time
/// Last revision date 
/// </summary>
public class PlayerMotor : MonoBehaviour
{
    private CharacterController characterController;
    //子控件下的摄像机
    public Transform camera;
    //帮助转向工具
    public Transform helpRotateTransform;
    private float helpX, helpY, helpZ;
    //子空间下的真实角色
    private Transform realPlayer;
    private Animator animator;
    //人物动画信息
    private PlayerAnimatorInfo playerAnimatorInfo;
    //人物信息
    private PlayerInfo playerInfo;
    //获取鼠标X轴和Y轴的移动
    private float mouseX, mouseY;
    //区分仰角和俯角
    private float rotationX;
    private void Start()
    {
        playerAnimatorInfo = GetComponent<PlayerAnimatorInfo>();
        realPlayer = GameObject.FindGameObjectWithTag("RealPlayer").transform;
        animator = realPlayer.GetComponent<Animator>();
        playerInfo = GetComponent<PlayerInfo>();
        characterController = GetComponent<CharacterController>();
        camera.localPosition = playerInfo.cameraLocalPosition;
        camera.localRotation = Quaternion.Euler(playerInfo.cameraLocalRotation);
    }
    void RealPlayerShouldRotation()
    {
        helpX = helpRotateTransform.localEulerAngles.x;
        helpY = helpRotateTransform.localEulerAngles.y;
        helpZ = helpRotateTransform.localEulerAngles.z;
    }
    void Update()
    {
        CameraRate();
        animator.SetBool(PlayerAnimatorInfo.walkHash, true);
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && playerInfo.canEnter)
        {
            RealPlayerShouldRotation();
            if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.W))
                    realPlayer.localRotation = Quaternion.RotateTowards(realPlayer.localRotation, Quaternion.Euler(new Vector3(helpX, helpY - 45, helpZ)), playerInfo.rotateSpeed * Time.deltaTime * 100);
                else if (Input.GetKey(KeyCode.S))
                    realPlayer.localRotation = Quaternion.RotateTowards(realPlayer.localRotation, Quaternion.Euler(new Vector3(helpX, helpY - 135, helpZ)), playerInfo.rotateSpeed * Time.deltaTime * 100);
                else if (!Input.GetKey(KeyCode.D))//内涵：!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)
                    realPlayer.localRotation = Quaternion.RotateTowards(realPlayer.localRotation, Quaternion.Euler(new Vector3(helpX, helpY - 90, helpZ)), playerInfo.rotateSpeed * Time.deltaTime * 100);
            }
            else if (Input.GetKey(KeyCode.D))
            {//已经不包含A
                if (Input.GetKey(KeyCode.W))
                    realPlayer.localRotation = Quaternion.RotateTowards(realPlayer.localRotation, Quaternion.Euler(new Vector3(helpX, helpY + 45, helpZ)), playerInfo.rotateSpeed * Time.deltaTime * 100);
                else if (Input.GetKey(KeyCode.S))
                    realPlayer.localRotation = Quaternion.RotateTowards(realPlayer.localRotation, Quaternion.Euler(new Vector3(helpX, helpY + 135, helpZ)), playerInfo.rotateSpeed * Time.deltaTime * 100);
                //else if (!Input.GetKey(KeyCode.A))//内涵：!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A)还有不可能为A
                realPlayer.localRotation = Quaternion.RotateTowards(realPlayer.localRotation, Quaternion.Euler(new Vector3(helpX, helpY + 90, helpZ)), playerInfo.rotateSpeed * Time.deltaTime * 100);
            }
            else if (Input.GetKey(KeyCode.W))
            {//已经不包含A,D
                if (!Input.GetKey(KeyCode.S))
                    realPlayer.localRotation = Quaternion.RotateTowards(realPlayer.localRotation, helpRotateTransform.rotation, playerInfo.rotateSpeed * Time.deltaTime * 100);
            }
            else if (Input.GetKey(KeyCode.S))
            {//已经不包含A,S,D
                realPlayer.localRotation = Quaternion.RotateTowards(realPlayer.localRotation, Quaternion.Euler(new Vector3(helpX, helpY - 180, helpZ)), playerInfo.rotateSpeed * Time.deltaTime * 100);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (playerInfo.canEnter)
                {
                    animator.speed = playerAnimatorInfo.runAniSpeed;
                    if (!playerInfo.runVfx.activeSelf)//加速特效开启
                    {
                        playerInfo.runVfx.SetActive(true);
                    }
                }
                characterController.SimpleMove(realPlayer.forward * playerInfo.runSpeed);
            }
            else
            {
                if (playerInfo.canEnter)
                {
                    animator.speed = playerAnimatorInfo.walkAniSpeed;
                    //加速特效关闭
                    if (playerInfo.runVfx.activeSelf)//加速特效开启
                    {
                        playerInfo.runVfx.SetActive(false);
                    }
                }
                characterController.SimpleMove(realPlayer.forward * playerInfo.walkSpeed);
            }
        }
        else
        {
            animator.SetBool(PlayerAnimatorInfo.walkHash, false);
        }
    }

    /// <summary>
    /// 控制摄像机旋转
    /// </summary>
    private void CameraRate()
    {
        mouseX = Input.GetAxis("Mouse X") * playerInfo.cameraXSpeed;
        mouseY = Input.GetAxis("Mouse Y") * playerInfo.cameraYSpeed;
        DistinguishRotationX();
        //Debug.Log(camera.localRotation.eulerAngles.x);//代码中的camera.localRotation.eulerAngles.x等于camera.eulerAngles.x只有0-360
        //Debug.Log(rotationX);
        if (mouseX != 0)
        {
            camera.RotateAround(transform.position, Vector3.up, mouseX);//沿着自身X轴旋转
            helpRotateTransform.Rotate(Vector3.up, mouseX);//记录现在正确的rotation
        }
        if (mouseY != 0)
        {
            if (rotationX >= playerInfo.cameraAngleOfElevation && mouseY > 0)
            {
                mouseY = 0;
            }
            if (rotationX <= playerInfo.cameraAngleOfDepression && mouseY < 0)
            {
                mouseY = 0;
            }
            camera.RotateAround(transform.position, camera.right, mouseY);//沿着自身X轴旋转
        }
    }

    /// <summary>
    /// 欧拉角只有0-360，超过180的用他减去360以区分
    /// </summary>
    void DistinguishRotationX()
    {
        if (camera.localRotation.eulerAngles.x/*transform组件上的Rotation.x值*/ > 180)
            rotationX = camera.localRotation.eulerAngles.x - 360;
        else rotationX = camera.localRotation.eulerAngles.x;
    }

}
