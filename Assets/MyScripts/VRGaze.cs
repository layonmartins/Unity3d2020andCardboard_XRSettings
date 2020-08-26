using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour
{
    public Image imgGaze;

    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay = 10;
    private RaycastHit _hit;
    // Start is called before the first frame update
    void Start()
    {
        imgGaze.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
            Debug.Log("imgGaze.fillAmount:" + imgGaze.fillAmount);
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if(Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            Debug.Log("imgGaze.fillAmount:" + imgGaze.fillAmount);

            if (imgGaze.fillAmount == 1f && _hit.transform.CompareTag("Teleport"))
            {
                _hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
            }

            if (imgGaze.fillAmount == 1f && _hit.transform.CompareTag("RotateCube") && gvrStatus)
            {
                _hit.transform.gameObject.GetComponent<RotateCube>().ChangeSpin();
                gvrStatus = false;
            }
            
        }
    }

    public void GVROn()
    {
        gvrStatus = true;
        Debug.Log("gvrStatus: " + gvrStatus);
    }

    public void GVROff()
    {
        Debug.Log("gvrStatus: " + gvrStatus);
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0f;
    }
}
