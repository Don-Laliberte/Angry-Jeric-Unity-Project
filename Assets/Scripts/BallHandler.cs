using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour{ 
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Rigidbody2D pivot;
    [SerializeField] private float detachDelay;
    [SerializeField] private float despawnDelay;
    [SerializeField] private float respawnDelay;
    
    [Header("Sound Effects")]
    [SerializeField] AudioClip[] effects;
    [SerializeField] float[] volume;

    SoundHandler soundHandler;
    
    private Rigidbody2D currentBallRigidBody;
    private SpringJoint2D currentBallSpringJoint;
    private Camera mainCamera;
    private bool isDragging;

    void Awake() {
        if (effects.Length != 0)
        soundHandler = new SoundHandler(effects, volume);
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        SpawnNewBall(); //Spawns in new ball
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHandler.winCondition) {
            return;
        }
        if (currentBallRigidBody == null) {
            return;
        }

        //If we are not touching the touch screen do not run the code
        if (!Touchscreen.current.primaryTouch.press.isPressed) {
            
            if (isDragging) {
                LaunchBall();
            }
            isDragging = false;

            return; //Any code after this line is not executed
        }

        isDragging = true;

        currentBallRigidBody.isKinematic = true; //Makes ball kinematic which means other forces do not act on it while it is being dragged

        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue(); //Note: Vector2 datatype stores a X and Y position

        Debug.Log(pivot.position.x);


        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition); //Converts screen position to world position
       
        if (worldPosition.x > pivot.position.x) {
            worldPosition.x = pivot.position.x;
        }


        currentBallRigidBody.position = worldPosition;

    }

    private void SpawnNewBall() {
        GameObject ballInstance = Instantiate(ballPrefab, pivot.position, Quaternion.identity); 
        currentBallRigidBody = ballInstance.GetComponent<Rigidbody2D>();
        currentBallSpringJoint = ballInstance.GetComponent<SpringJoint2D>();

        currentBallSpringJoint.connectedBody = pivot;
    }

    private void DespawnBall() {
        Destroy(gameObject);
    }
    private void LaunchBall() {
        currentBallRigidBody.isKinematic = false;
        currentBallRigidBody = null;
        Invoke(nameof(DetachBall), detachDelay); //Invokes detach ball after a certain amount of time
        if (despawnDelay != -1) {
            Invoke(nameof(DespawnBall), despawnDelay);
        }

    }

    private void DetachBall() {
        soundHandler.playRandomSound();
        currentBallSpringJoint.enabled = false;
        currentBallSpringJoint = null;
        Invoke(nameof(SpawnNewBall), respawnDelay); //Spawns new ball
    }

}
