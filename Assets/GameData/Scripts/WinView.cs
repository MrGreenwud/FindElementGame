using UnityEngine;

public class WinView : MonoBehaviour
{
    [SerializeField] private GameObject _startParticle;

    public void Show(Cell cell, bool isValid)
    {
        if (isValid == false)
            return;

        _startParticle.SetActive(true);

        float x = cell.transform.position.x;
        float y = cell.transform.position.y;
        float z = _startParticle.transform.position.z;

        _startParticle.transform.position = new Vector3(x, y, z);
    }

    public void Hide()
    {
        _startParticle.SetActive(false);
    }
}
