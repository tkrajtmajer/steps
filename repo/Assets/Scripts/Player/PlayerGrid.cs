using UnityEngine;

public class PlayerGrid : MonoBehaviour
{
    public float speed = 7f;
    public Transform movePoint;

    public LayerMask movementStop;
    public LayerMask pushLayer;


    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null; //better organized

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }


    void Move()
    {
        Collider2D colliderOverlapingCircle_x = Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0), 0.2f, pushLayer);
        Collider2D colliderOverlapingCircle_y = Physics2D.OverlapCircle(movePoint.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0), 0.2f, pushLayer);
        //move player to point
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if ((Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0), 0.4f, movementStop) == null && !colliderOverlapingCircle_x)
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                }

                //ovo je prije nego se movepoint i consequently player obj moveaju
                if (colliderOverlapingCircle_x)
                {
                    //treba pomjerit prvo other obj onda move point

                    Debug.Log(colliderOverlapingCircle_x);
                    colliderOverlapingCircle_x.gameObject.transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                    //movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                }

            }
            else if ((Input.GetAxisRaw("Horizontal")) == -1f)
            {
                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0), 0.4f, movementStop) == null && !colliderOverlapingCircle_x)
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                }

                //ovo je prije nego se movepoint i consequently player obj moveaju
                if (colliderOverlapingCircle_x)
                {
                    //treba pomjerit prvo other obj onda move point

                    Debug.Log(colliderOverlapingCircle_x);
                    colliderOverlapingCircle_x.gameObject.transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                    //movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                }
            }

            if ((Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0), 0.4f, movementStop) == null && !colliderOverlapingCircle_y)
                {
                    movePoint.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
                }

                //ovo je prije nego se movepoint i consequently player obj moveaju
                if (colliderOverlapingCircle_y)
                {
                    //treba pomjerit prvo other obj onda move point

                    Debug.Log(colliderOverlapingCircle_y);
                    colliderOverlapingCircle_y.gameObject.transform.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
                    //movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                }
            }
            else if ((Input.GetAxisRaw("Vertical")) == -1f)
            {
                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0), 0.4f, movementStop) == null && !colliderOverlapingCircle_y)
                {
                    movePoint.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
                }

                //ovo je prije nego se movepoint i consequently player obj moveaju
                if (colliderOverlapingCircle_y)
                {
                    //treba pomjerit prvo other obj onda move point

                    Debug.Log(colliderOverlapingCircle_y);
                    colliderOverlapingCircle_y.gameObject.transform.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
                    //movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                }
            }
        }

    }


   
}
