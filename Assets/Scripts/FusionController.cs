using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class FusionController : MonoBehaviour
{
    public float startDelay = 1.0f; // Time before the first call
    public int interval = 20;   // Interval between calls
    public float Speed = 10;
    public GameObject FusionAnimation;
    public Slider Slider;

    private float passedTime;

    private async void Start()
    {
        FusionAnimation.SetActive(false);
        await Task.Delay(interval * 1000);
        RepeatAction();
    }

    private void FixedUpdate()
    {
        passedTime += Time.fixedDeltaTime;
        if(passedTime > ReferenceSingleton.Instance.FusionTimer)
        {
            RepeatAction();
            ReferenceSingleton.Instance.FusionTimer = float.PositiveInfinity;
        }

        Slider.value = passedTime / ReferenceSingleton.Instance.FusionTimer;
    }

    void RepeatAction()
    {
        CharacterMover[] allChars = FindObjectsOfType<CharacterMover>();
        foreach (CharacterMover mover in allChars)
        {
            mover.enabled = false;
        }

        StartCoroutine(MoveObjectsTowardsEachOther());
    }

    private IEnumerator MoveObjectsTowardsEachOther()
    {
        Transform object1 = ReferenceSingleton.Instance.Player1;
        Transform object2 = ReferenceSingleton.Instance.Player2;

        // Continue the loop until the objects are close enough
        while (Vector3.Distance(object1.position, object2.position) > 0.5f)
        {
            object1.position = Vector3.MoveTowards(object1.position, object2.position, Speed * Time.deltaTime);
            object2.position = Vector3.MoveTowards(object2.position, object1.position, Speed * Time.deltaTime);

            // Wait until the next frame
            yield return null;
        }

        // Call the method when the objects have reached each other
        OnObjectsReachedEachOther();
    }

    private async void OnObjectsReachedEachOther()
    {
        ReferenceSingleton.Instance.Fusioned = true;

        CharacterMover[] allChars = FindObjectsOfType<CharacterMover>();
        foreach (CharacterMover mover in allChars)
        {
            if (mover.FirstPlayer)
            {
                mover.enabled = true;
                mover.transform.GetChild(0).gameObject.SetActive(false);
                mover.transform.GetChild(2).gameObject.SetActive(true);
            }
                
            else
            {
                mover.gameObject.SetActive(false);
            }
        }
        FusionAnimation.SetActive(true);
        FusionAnimation.transform.position = allChars[0].transform.position;
        await Task.Delay(1100);
        FusionAnimation.SetActive(false);
    }
}
